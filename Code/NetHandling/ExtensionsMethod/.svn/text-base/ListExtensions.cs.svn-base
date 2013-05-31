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
using System.Collections;
using System.Windows.Forms;

using PorpinoHandling.Model;

namespace PorpinoHandling.ExtensionsMethod
{
    public static class ListExtensions
    {
		public static IEnumerable<T> MoveDown<T>(this IEnumerable<T> source, int index)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			T[] array = source.ToArray();
			if (index == array.Length - 1)
			{
				return source;
			}
			return Swap<T>(array, index, index + 1);
		}

		public static IEnumerable<T> MoveDown<T>(this IEnumerable<T> source, T item)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			T[] array = source.ToArray();
			int index = Array.FindIndex(array, i => i.Equals(item));
			if (index == -1)
			{
				throw new InvalidOperationException();
			}
			if (index == array.Length - 1)
			{
				return source;
			}
			return Swap<T>(array, index, index + 1);
		}

		public static IEnumerable<T> MoveUp<T>(this IEnumerable<T> source, int index)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			T[] array = source.ToArray();
			if (index == 0)
			{
				return source;
			}
			return Swap<T>(array, index - 1, index);
		}

		public static IEnumerable<T> MoveUp<T>(this IEnumerable<T> source, T item)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			T[] array = source.ToArray();
			int index = Array.FindIndex(array, i => i.Equals(item));
			if (index == -1)
			{
				throw new InvalidOperationException();
			}
			if (index == 0)
			{
				return source;
			}
			return Swap<T>(array, index - 1, index);
		}

		public static IEnumerable<T> Swap<T>(this IEnumerable<T> source, int firstIndex, int secondIndex)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			T[] array = source.ToArray();
			return Swap<T>(array, firstIndex, secondIndex);
		}

		private static IEnumerable<T> Swap<T>(T[] array, int firstIndex, int secondIndex)
		{
			if (firstIndex < 0 || firstIndex >= array.Length)
			{
				throw new ArgumentOutOfRangeException("firstIndex");
			}
			if (secondIndex < 0 || secondIndex >= array.Length)
			{
				throw new ArgumentOutOfRangeException("secondIndex");
			}
			T tmp = array[firstIndex];
			array[firstIndex] = array[secondIndex];
			array[secondIndex] = tmp;
			return array;
		}

		public static IEnumerable<T> Swap<T>(this IEnumerable<T> source, T firstItem, T secondItem)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			T[] array = source.ToArray();
			int firstIndex = Array.FindIndex(array, i => i.Equals(firstItem));
			int secondIndex = Array.FindIndex(array, i => i.Equals(secondItem));
			return Swap(array, firstIndex, secondIndex);
		}

		public static UniqueList<T> ToUniqueList<T>(this IEnumerable<T> source)
		{
			return ToUniqueList(source, false);
		}

		public static UniqueList<T> ToUniqueList<T>(this IEnumerable<T> source, bool force)
		{
			UniqueList<T> list = new UniqueList<T>();

			foreach (T t in source)
			{
				list.Add(t, force);
			}

			return list;
		}

		public static IEnumerable<T> ToInverse<T>(this IEnumerable<T> source)
		{
			List<T> list = new List<T>();

			foreach (T t in source)
			{
				list.Add(t);
			}

			list.Reverse();

			return list;
		}

    }
}
