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
    public static class SerializeExtensions
    {
       

		public static T DeserializeTo<T>(this String xmlPath) where T : new()
		{
			T t = new T();
			XmlSerializer serializer = new XmlSerializer(t.GetType());
			StreamReader reader = new StreamReader( xmlPath);
			object deserialized = null;
			try
			{
				deserialized = serializer.Deserialize(reader.BaseStream);
			}
			finally
			{
				reader.Close();
			}

			return (T)deserialized;
		}

		public static void SerializeTo<T>(this T t, String xmlPath)
		{
			XmlSerializer serializer = new XmlSerializer(t.GetType());
			StreamWriter writer = new StreamWriter( xmlPath);

			serializer.Serialize(writer.BaseStream, t);
			writer.Close();

		}

		

    }
}
