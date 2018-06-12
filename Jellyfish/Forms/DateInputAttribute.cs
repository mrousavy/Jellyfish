using System;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="DateTime" /> objects generating a <see cref="DatePicker" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DateInputAttribute : Attribute, IFormInput<DateTime>
    {
        public DateInputAttribute(string text)
        {
            Text = text;
        }
        public DateInputAttribute() : this("")
        {
        }

        public string Text { get; set; }
    }
}
