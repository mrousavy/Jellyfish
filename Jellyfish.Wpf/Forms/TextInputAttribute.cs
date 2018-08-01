using System;

namespace Jellyfish.Wpf.Forms
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
        { }

        public TextInputAttribute() : this("")
        { }

        /// <summary>
        ///     The formatter to use for custom formatting the field
        /// </summary>
        /// <example>
        ///     You can define a formatter to display hours like this:
        ///     var formatter = val => $"{val}h";
        /// </example>
        public Func<string, string> Formatter { get; set; }

        public string Text { get; set; }
    }
}