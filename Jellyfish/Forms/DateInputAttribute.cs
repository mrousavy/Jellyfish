using System;
using System.Windows.Controls;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="DateTime" /> objects generating a <see cref="DatePicker" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DateInputAttribute : Attribute, IFormInput<DateTime>
    {
        public DateInputAttribute(string text, Func<DateTime, DateTime> formatter)
        {
            Text = text;
            Formatter = formatter;
        }
        public DateInputAttribute(string text) : this(text, t => t)
        {
        }
        public DateInputAttribute() : this("")
        {
        }

        public Func<DateTime, DateTime> Formatter { get; set; }
        public string Text { get; set; }
    }
}
