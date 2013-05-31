using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorpinoHandling.Manager
{
	public class ILoggerImpl
	{
		public ILoggerImpl()
		{
			Logs = new List<ILogImpl>();
		}

		public List<ILogImpl> Logs { get; set; }

		public override bool Equals(object obj)
		{
			return obj.GetType() == this.GetType();
		}

		public override int GetHashCode()
		{
			return this.GetType().GetHashCode();
		}

		public void Log(String message)
		{
			Logs.Add(new ILogImpl()
			{
				Message = message,
				Time = DateTime.Now
			});
		}
	}
}
