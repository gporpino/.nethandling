using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PorpinoHandling.Manager
{
	public class ILogImpl:ILog
	{

		[XmlIgnore]
		public DateTime Time { get; set; }

		[XmlAttribute]
		public String Message
		{
			get;
			set;
		}

		[XmlAttribute("Time")]
		private string TimeString
		{
			get { return Time.ToString(); }
			set { Time = DateTime.Parse(value); }
		}

		

		public override string ToString()
		{
			DateTime now = DateTime.Now;
			return String.Format("{0} {1}: {2}", now.ToShortDateString(), now.ToShortTimeString(), Message);	
		}

	}
}
