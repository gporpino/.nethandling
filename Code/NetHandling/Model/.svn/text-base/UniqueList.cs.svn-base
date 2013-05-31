using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorpinoHandling.Model
{
	public class UniqueList<T> : List<T>
	{
		public new void Add(T obj) 
		{
			Add(obj, false);
		}

		public new void Add(T obj, bool force)
		{
			
			if (force)
			{
				base.Remove(obj);
				base.Add(obj);
			}
			else
			{
				if (!Contains(obj))
				{
					base.Add(obj);
					this.AsReadOnly();
				}
				else
				{
					throw new InvalidOperationException("This object is already at unique list.");
				}
			}
		}
	}
}
