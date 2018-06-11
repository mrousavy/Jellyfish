using System.ComponentModel;

namespace Jellyfish.Demo
{
    public enum OperatingSystem
    {
        [Description("Linux")]
        Linux,
        [Description("Microsoft Windows")]
        Windows,
        [Description("Apple Darwin")]
        Darwin,
        [Description("Linux/Android")]
        Android
    }
}
