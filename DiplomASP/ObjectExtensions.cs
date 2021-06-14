using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DiplomASP
{
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                var prop = someObjectType.GetProperty(item.Key);
                if (prop.PropertyType == typeof(int) && item.Value.GetType() == typeof(string))
                    prop.SetValue(someObject, Int32.Parse((string)item.Value), null);
                else
                    prop.SetValue(someObject, item.Value, null);
            }

            return someObject;
        }

        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }

        public static T ToObjectStatic<T>(IDictionary<string, object> source)
    where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                var prop = someObjectType.GetProperty(item.Key);
                if (prop.PropertyType == typeof(int) && item.Value.GetType() == typeof(string))
                    prop.SetValue(someObject, Int32.Parse((string)item.Value), null);
                else
                    prop.SetValue(someObject, item.Value, null);
            }

            return someObject;
        }

        //public static int Value(this string str)
        //{
        //    return Int32.Parse(str);
        //}
    }
}
