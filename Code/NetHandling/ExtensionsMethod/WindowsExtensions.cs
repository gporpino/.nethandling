using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

using System.Security;
using System.Globalization;
using System.Threading;
using System.Security.Principal;

namespace PorpinoHandling.ExtensionsMethod
{
    public static class WindowsExtensions
    {
		public static String GetFullName(this WindowsIdentity identy)
		{
			String enterpriseID = identy.Name.Split('\\').Last();

			StringBuilder sb = new StringBuilder();
			foreach (String name in enterpriseID.Split('.'))
			{

				CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
				TextInfo textInfo = cultureInfo.TextInfo;

				sb.Append(textInfo.ToTitleCase(name) + " ");
				if (name.Length == 1)
				{
					sb.Append(".");
				}
			}

			return sb.ToString();
		}
    }
}
