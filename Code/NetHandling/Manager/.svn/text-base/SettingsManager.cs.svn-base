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
	public class SettingsManager
	{
		private static String _xmlApplicationPath = "";
		private static String _xmlSettingsPath = @"Settings\";

		private static SettingsManager _instance;

		private List<ISettingsImpl> settings;


		private SettingsManager(){
			settings = new List<ISettingsImpl>();
		}

		public static SettingsManager GetInstance(String path)
		{

			_xmlApplicationPath = path;
			if (_instance == null)
			{
				_instance = new SettingsManager();
			}

			return _instance;
			
		}

		private static SettingsManager GetInstance()
		{
			_xmlApplicationPath = "";
			if (_instance == null)
			{
				_instance = new SettingsManager();
			}

			return _instance;

		}

		public T GetSettings<T>() where T : ISettingsImpl, new()
		{
			String xmlPath = _xmlApplicationPath + @"\" + _xmlSettingsPath + typeof(T).Name + ".xml";

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

		public void Commit()
		{
			foreach (ISettingsImpl s in settings)
			{
				s.SerializeTo(_xmlApplicationPath + @"\" + _xmlSettingsPath + s.GetType().Name + ".xml");
			}

			settings.Clear();
		}

		public void Commit<T>() where T : ISettingsImpl, new()
		{
			T t = (T)settings.SingleOrDefault(s => s.GetType() == typeof(T));
			t.SerializeTo( _xmlSettingsPath + t.GetType().Name + ".xml" );
			settings.Remove(t);
		}
	}


}

