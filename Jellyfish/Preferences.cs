using Jellyfish.Exceptions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Jellyfish
{
    /// <summary>
    ///     An abstract class definition of an application preferences manager which loads and saves JSON Preferences
    /// </summary>
    public abstract class Preferences
    {
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

        private string Path { get; }

        /// <summary>
        ///     Initialize the Preferences construct
        /// </summary>
        /// <param name="path">The Path to the preferences file (See <see cref="RecommendedPath"/></param>
        protected Preferences(string path)
        {
            Path = path;
        }

        /// <summary>
        ///     Initialize the Preferences construct
        /// </summary>
        protected Preferences()
        {
        }

        /// <summary>
        ///     Load a preferences instance from the given file
        /// </summary>
        /// <typeparam name="TPreferences">The type of the Preferences (must inherit from <see cref="Preferences"/>)</typeparam>
        /// <param name="path">The path to the preferences file (See <see cref="RecommendedPath"/>)</param>
        /// <returns>A deserialized instance of the preferences</returns>
        public static TPreferences Load<TPreferences>(string path) where TPreferences : Preferences
        {
            if (!File.Exists(path))
                throw new PreferencesFileNotFoundException(path);

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<TPreferences>(json);
        }

        /// <summary>
        ///     Serialize and save the preferences instance to the preferences file (<see cref="Path"/>)
        /// </summary>
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(Path, json);
        }

        /// <summary>
        ///     Serialize and save the preferences instance to the preferences file (<see cref="Path"/>) asynchronous
        /// </summary>
        public async Task SaveAsync()
        {
            string json = JsonConvert.SerializeObject(this);
            var content = Encoding.Unicode.GetBytes(json);

            using (var sourceStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.None, 4096, true))
            {
                await sourceStream.WriteAsync(content, 0, content.Length);
            }
        }

        /// <summary>
        ///     Checks if the Preferences file exists and creates it if it doesn't
        /// </summary>
        /// <returns>Whether the file was created or not</returns>
        public bool EnsureExists()
        {
            var file = new FileInfo(Path);
            var directory = file.Directory;

            if (directory != null)
            {
                if (!directory.Exists)
                {
                    directory.Create();
                }
            }

            if (file.Exists)
                return false;

            file.Create().Dispose();
            return true;
        }
    }
}
