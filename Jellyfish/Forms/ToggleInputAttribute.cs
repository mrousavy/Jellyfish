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
        public ToggleInputAttribute(string text)
        {
            Text = text;
        }
        public ToggleInputAttribute() : this("")
        {
        }

        public string Text { get; set; }
    }
}
