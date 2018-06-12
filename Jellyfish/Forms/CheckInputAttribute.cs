using System;
using System.Windows.Controls;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="bool" /> objects generating a <see cref="CheckBox" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CheckInputAttribute : Attribute, IFormInput<bool>
    {
        public CheckInputAttribute(string text, Func<bool, bool> formatter)
        {
            Text = text;
            Formatter = formatter;
        }
        public CheckInputAttribute(string text) : this(text, t => t)
        {
            Text = text;
        }
        public CheckInputAttribute() : this("")
        {
        }

        public Func<bool, bool> Formatter { get; set; }
        public string Text { get; set; }
    }
}
