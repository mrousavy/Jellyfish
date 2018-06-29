using System;
using System.Runtime.CompilerServices;

namespace Jellyfish
{
    [AttributeUsage(AttributeTargets.All)]
    public class DependencyAttribute : Attribute
    {
        public DependencyAttribute([CallerMemberName] string propertyName = null)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; set; }
    }
}
