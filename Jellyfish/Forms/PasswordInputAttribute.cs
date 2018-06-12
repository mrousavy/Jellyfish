using System;
using System.Security;
using System.Windows.Controls;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="SecureString" /> objects (Passwords) generating a <see cref="PasswordBox" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PasswordInputAttribute : Attribute, IFormInput<SecureString>
    {
        public PasswordInputAttribute(string text)
        {
            Text = text;
        }
        public PasswordInputAttribute() : this("")
        {
        }

        public Func<SecureString, SecureString> Formatter { get; set; }
        public string Text { get; set; }
    }
}
