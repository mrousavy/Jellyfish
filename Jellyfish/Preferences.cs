using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jellyfish.Exceptions;
using Newtonsoft.Json;

namespace Jellyfish
{
    /// <summary>
    ///     An abstract class definition of an application preferences manager which loads and saves JSON Preferences
    /// </summary>
    public abstract class Preferences
    {
        /// <summary>
        ///     Initialize the Preferences construct
        /// </summary>
        /// <param name="path">The Path to the preferences file (See <see cref="RecommendedPath" /></param>
        protected Preferences(string path)
        {
            Path = path;
        }

        /// <summary>
        ///     The size of the buffer for the filestream in bytes
        /// </summary>
        public static int FileBufferSize { get; set; } = 4096;

        /// <summary>
        ///     Path to the Application Data directory (%AppData%)
        /// </summary>
        public static string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        ///     Name of the calling executable
        /// </summary>
        public static string ExecutableName => Process.GetCurrentProcess().ProcessName;

        /// <summary>
        ///     The recommended path of the Preferences file (<c>%AppData%\[app name]\config.json</c>)
        /// </summary>
        public static string RecommendedPath => System.IO.Path.Combine(AppData, ExecutableName, "config.json");

        [JsonIgnore]
        private string Path { get; set; }

        /// <summary>
        ///     Load a preferences instance from the given file
        /// </summary>
        /// <typeparam name="TPreferences">The type of the Preferences (must inherit from <see cref="Preferences" />)</typeparam>
        /// <param name="path">The path to the preferences file (See <see cref="RecommendedPath" />)</param>
        /// <returns>A deserialized instance of the preferences</returns>
        public static TPreferences Load<TPreferences>(string path) where TPreferences : Preferences
        {
            if (!File.Exists(path))
                throw new PreferencesFileNotFoundException(path);

            string json = File.ReadAllText(path);
            var preferences = JsonConvert.DeserializeObject<TPreferences>(json);
            preferences.Path = path;
            return preferences;
        }

        /// <summary>
        ///     Load a preferences instance from the given file asynchronously
        /// </summary>
        /// <typeparam name="TPreferences">The type of the Preferences (must inherit from <see cref="Preferences" />)</typeparam>
        /// <param name="path">The path to the preferences file (See <see cref="RecommendedPath" />)</param>
        /// <returns>A deserialized instance of the preferences</returns>
        public static async Task<TPreferences> LoadAsync<TPreferences>(string path) where TPreferences : Preferences
        {
            if (!File.Exists(path))
                throw new PreferencesFileNotFoundException(path);

            // Read file async
            var bytes = new List<byte>();
            using (var sourceStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None,
                FileBufferSize, true))
            {
                int read;
                do
                {
                    var buffer = new byte[1024];
                    read = await sourceStream.ReadAsync(buffer, 0, FileBufferSize).ConfigureAwait(false);
                    bytes.AddRange(buffer);
                } while (read > 0);
            }

            string json = Encoding.Unicode.GetString(bytes.ToArray());
            var preferences = JsonConvert.DeserializeObject<TPreferences>(json);
            preferences.Path = path;
            return preferences;
        }

        /// <summary>
        ///     Load a preferences instance from the given file or return null if not found
        /// </summary>
        /// <typeparam name="TPreferences">The type of the Preferences (must inherit from <see cref="Preferences" />)</typeparam>
        /// <param name="path">The path to the preferences file (See <see cref="RecommendedPath" />)</param>
        /// <returns>A deserialized instance of the preferences</returns>
        public static TPreferences LoadOrDefault<TPreferences>(string path) where TPreferences : Preferences
        {
            if (!File.Exists(path))
                return default(TPreferences);

            string json = File.ReadAllText(path);
            var preferences = JsonConvert.DeserializeObject<TPreferences>(json);
            preferences.Path = path;
            return preferences;
        }

        /// <summary>
        ///     Load a preferences instance from the given file asynchronously or return null if not found
        /// </summary>
        /// <typeparam name="TPreferences">The type of the Preferences (must inherit from <see cref="Preferences" />)</typeparam>
        /// <param name="path">The path to the preferences file (See <see cref="RecommendedPath" />)</param>
        /// <returns>A deserialized instance of the preferences</returns>
        public static async Task<TPreferences> LoadOrDefaultAsync<TPreferences>(string path)
            where TPreferences : Preferences
        {
            if (!File.Exists(path))
                return default(TPreferences);

            // Read file async
            var bytes = new List<byte>();
            using (var sourceStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None,
                FileBufferSize, true))
            {
                int read;
                do
                {
                    var buffer = new byte[1024];
                    read = await sourceStream.ReadAsync(buffer, 0, FileBufferSize).ConfigureAwait(false);
                    bytes.AddRange(buffer);
                } while (read > 0);
            }

            string json = Encoding.Unicode.GetString(bytes.ToArray());
            var preferences = JsonConvert.DeserializeObject<TPreferences>(json);
            preferences.Path = path;
            return preferences;
        }

        /// <summary>
        ///     Serialize and save the preferences instance to the preferences file (<see cref="Path" />)
        /// </summary>
        public void Save()
        {
            CreateDirectory();
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(Path, json);
        }

        /// <summary>
        ///     Serialize and save the preferences instance to the preferences file (<see cref="Path" />) asynchronous
        /// </summary>
        public async Task SaveAsync()
        {
            CreateDirectory();
            string json = JsonConvert.SerializeObject(this);
            var content = Encoding.Unicode.GetBytes(json);

            using (var sourceStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.None,
                FileBufferSize, true))
            {
                await sourceStream.WriteAsync(content, 0, content.Length).ConfigureAwait(false);
            }
        }

        private void CreateDirectory()
        {
            var file = new FileInfo(Path);
            var directory = file.Directory;

            if (directory != null)
                if (!directory.Exists)
                    directory.Create();
        }
    }
}