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
    public static class ObjectExtensions
    {
		private static Dictionary<Object, Dictionary<String, String>> dic = new Dictionary<Object, Dictionary<String, String>>();

		public static T CastTo<T>(this Object obj)
		{
			try
			{
				return (T)obj;
			}
			catch
			{
				return default(T);
			}
		}

		public static bool IsEmpty<T>(this T obj)
		{
			return obj == null || obj.ToString() == String.Empty;
		}

		public static String Eval<T>(this T obj, Func<T, Object> func)
		{
			try
			{
				return func(obj).ToString();
			}
			catch
			{
				return String.Empty;
			}
		}

		public static String GetData<T>(this T t, String keyData) where T : new()
		{
			Dictionary<String, String> dicData = null;
			if (dic.ContainsKey(t))
			{
				dicData = dic[t];
				return dicData[keyData];
			}

			return null;
		}

		public static void SetData<T>(this T t, String keyData, String data) where T : new()
		{
			Dictionary<String, String> dicData = null;

			if (!dic.ContainsKey(t))
			{
				dicData = new Dictionary<string, string>();
			}
			else
			{
				dicData = dic[t];
			}
			dicData.Add(keyData, data);
			dic.Add(t, dicData);

		}
		
    }
}
