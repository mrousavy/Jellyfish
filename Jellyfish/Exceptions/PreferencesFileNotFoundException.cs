using System;

namespace Jellyfish.Exceptions
{
    public class PreferencesFileNotFoundException : Exception
    {
        private static readonly string Nl = Environment.NewLine;
        public string Path { get; }

        public PreferencesFileNotFoundException(string path) :
            base($"The Preferences file could not be found!{Nl}" +
                 $"Use `Preferences.EnsureExists()` to ensure that the preferences file exists!{Nl}" +
                 $"Path: {path}")
        {
            Path = path;
        }
    }
}
