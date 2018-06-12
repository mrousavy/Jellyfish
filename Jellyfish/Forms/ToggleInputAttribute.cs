using System;
using System.Windows.Controls.Primitives;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="bool" /> objects generating a <see cref="ToggleButton" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ToggleInputAttribute : Attribute, IFormInput<bool>
    {
        public ToggleInputAttribute(string text, Func<bool, bool> formatter)
        {
            Text = text;
            Formatter = formatter;
        }
        public ToggleInputAttribute(string text) : this(text, t => t)
        {
        }
        public ToggleInputAttribute() : this("")
        {
        }

        public Func<bool, bool> Formatter { get; set; }
        public string Text { get; set; }
    }
}
