using System;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     NOT IMPLEMENTED
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DoubleInputAttribute : Attribute, IFormInput<double>
    {
        public DoubleInputAttribute(string text, Func<double, double> formatter)
        {
            Text = text;
            Formatter = formatter;
        }
        public DoubleInputAttribute(string text) : this(text, t => t)
        {
        }
        public DoubleInputAttribute() : this("")
        {
        }

        public Func<double, double> Formatter { get; set; }
        public string Text { get; set; }
    }
}
