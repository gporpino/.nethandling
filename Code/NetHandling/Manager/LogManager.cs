using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Reflection;
using PorpinoHandling.ExtensionsMethod;


namespace PorpinoHandling.Manager
{
	public class LogManager
	{
		private static String xmlSettingsPath = @"Log\";

		private static LogManager instance;

		private List<ILoggerImpl> settings;

		private void CreateIfMissing(string path)
		{
			bool folderExists = Directory.Exists(path);
			if (!folderExists)
				Directory.CreateDirectory(path);
		}

		private LogManager()
		{
			CreateIfMissing(xmlSettingsPath);
			settings = new List<ILoggerImpl>();
		}

		public static LogManager Instance{
			get
			{
				if (instance == null)
				{
					instance = new LogManager();
				}

				return instance;
			}
		}

		public T GetLogger<T>() where T : ILoggerImpl, new()
		{
			String xmlPath = xmlSettingsPath + typeof(T).Name + ".xml";

			if (!File.Exists(xmlPath))
			{
				T t = new T();
				t.SerializeTo(xmlPath);
			}

			T set = xmlPath.DeserializeTo<T>();
			settings.Remove(set);
			settings.Add(set);

			return set.CastTo<T>();
		}

		public ILoggerImpl GetLogger()
		{
			return GetLogger<ILoggerImpl>();
		}

		public void Commit()
		{
			foreach (ILoggerImpl s in settings)
			{
				s.SerializeTo(xmlSettingsPath + s.GetType().Name + ".xml");
			}

			settings.Clear();
		}

		public void Commit<T>() where T : ILoggerImpl, new()
		{
			T t = (T)settings.SingleOrDefault(s => s.GetType() == typeof(T));
			t.SerializeTo( xmlSettingsPath + t.GetType().Name + ".xml" );
			settings.Remove(t);
		}
	}


}

