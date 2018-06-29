using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jellyfish
{
    public static class Reflection
    {
        public static IEnumerable<PropertyInfo> PropertiesWithAttribute(this Type classType, Type attributeType)
        {
            var properties = classType.GetProperties();
            return properties.Where(p => p.CustomAttributes.Any(a => a.AttributeType == attributeType));
        }
    }
}
