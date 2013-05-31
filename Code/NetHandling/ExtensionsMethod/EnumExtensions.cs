using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

using System.Security;
using PorpinoHandling.Model.Attributes;

namespace PorpinoHandling.ExtensionsMethod
{
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static List<T> Values<T>(this T t) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            List<T> list = new List<T>();

            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

		public static string Value(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());

			ValueAttribute attribute
					= Attribute.GetCustomAttribute(field, typeof(ValueAttribute))
						as ValueAttribute;

			return attribute == null ? value.ToString() : attribute.Value;
		}

    }
}
