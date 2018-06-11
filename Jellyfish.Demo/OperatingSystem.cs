using System.ComponentModel;
using Jellyfish.Extensions;

namespace Jellyfish.Demo
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
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
