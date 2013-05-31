using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

using System.Security;

namespace PorpinoHandling.ExtensionsMethod
{
    public static class StringExtensions
    {
		public static SecureString ToSecureString(this String str)
		{
			SecureString secure = new SecureString(); 
			foreach (char c in str){
				secure.AppendChar(c);
			}
			return secure;
		}

		public static DateTime ToDateTime(this String stringDate)
		{
			try
			{
				return DateTime.Parse(stringDate);
			}
			catch
			{
				throw new Exception("Cannot convert string to DateTime.");
			}
		}

		public static String ToFormatedDate(this String stringDate)
		{
			try
			{
				return String.Format("{0:dd/MM/yyyy}", stringDate.ToDateTime());
			}
			catch
			{
				return String.Empty;
			}
		}

		public static T ToEnum<T>(this string description)
		{
			var type = typeof(T);
			if (!type.IsEnum) throw new InvalidOperationException();
			foreach (var field in type.GetFields())
			{
				var attribute = Attribute.GetCustomAttribute(field,
					typeof(DescriptionAttribute)) as DescriptionAttribute;
				if (attribute != null)
				{
					if (attribute.Description == description)
						return (T)field.GetValue(null);
				}
				else
				{
					if (field.Name == description)
						return (T)field.GetValue(null);
				}
			}
			throw new ArgumentException("Not found.", "description");
		}

		public static int ToInteger(this String str)
		{
			try
			{
				return Convert.ToInt32(str);
			}
			catch
			{
				return 0;
			}
		}
    }
}
