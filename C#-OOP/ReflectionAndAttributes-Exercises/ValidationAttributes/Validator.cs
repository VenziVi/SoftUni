using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertys = obj.GetType().GetProperties();

            foreach (PropertyInfo property in propertys)
            {
                var propertyCustomAttribute = property.GetCustomAttributes<MyValidationAttribute>();

                foreach (var attribute in propertyCustomAttribute)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
