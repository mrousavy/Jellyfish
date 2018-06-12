using System;
using System.Windows.Controls;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="string" /> objects generating a <see cref="TextBox" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TextInputAttribute : Attribute, IFormInput<string>
    {
        public TextInputAttribute(string text, Func<string, string> formatter)
        {
            Text = text;
            Formatter = formatter;
        }
        public TextInputAttribute(string text) : this(text, t => t)
        {
        }
        public TextInputAttribute() : this("")
        {
        }

        public Func<string, string> Formatter { get; set; }
        public string Text { get; set; }
    }
}
