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

namespace PorpinoHandling.ExtensionsMethod
{
    public static class UIExtensions
    {
		public static void ValidateRequiredField<T>(this T t, String fieldName) where T : Control, new()
		{
			bool valid = true;
			if (t is ComboBox)
			{
				ComboBox combo = (ComboBox)(Object)t;
				if (combo.SelectedItem == null)
				{
					valid = false;
				}

			}
			else if (t is TextBox)
			{
				TextBox field = (TextBox)(Object)t;
				if (field.Text == "")
				{
					valid = false;
				}

			}
			else if (t is TreeView)
			{
				TreeView field = (TreeView)(Object)t;
				if (field.HasChildren)
				{
					valid = false;
				}
			}

			if (!valid)
			{
				t.Focus();
				throw new InvalidDataException("O campo " + fieldName + " é obrigatório.");
			}

		}

		public static void ValidateRequiredField<T, X>(this T t, Func<T, X> func, String errorMessage) where T : Control, new()
		{
			bool valid = true;

			X x = func(t);

			if (x == null)
			{
				valid = false;
			}
			else if (x is String)
			{
				String s = (String)(Object)x;
				if (s == "")
				{
					valid = false;
				}
			}
			else if (x is ICollection)
			{
				ICollection list = (ICollection)(Object)x;
				if (list.Count == 0)
				{
					valid = false;
				}
			}

			if (!valid)
			{
				t.Focus();
				throw new InvalidDataException(errorMessage);
			}

		}

		public static void Populate<T>(this ComboBox combo, List<T> list, Func<T, String> funcItem)
		{
			combo.Items.Clear();
			foreach (T t in list)
			{
				String item = funcItem(t);

				combo.Items.Add(item);
			}

		}

		public static List<TreeNode> AllNodes(this TreeView t)
		{
			try
			{
				return AllNodes(t.TopNode);
			}
			catch
			{
				return null;
			}

		}

		private static List<TreeNode> AllNodes(TreeNode node)
		{
			List<TreeNode> list = new List<TreeNode>();
			list.Add(node);
			foreach (TreeNode child in node.Nodes)
			{
				list.AddRange(AllNodes(child));
			}

			return list;
		}

		public static void ShowBalloon(this NotifyIcon notifyIcon, String message)
		{
			notifyIcon.ShowBalloon("", message);
		}

		public static void ShowBalloon(this NotifyIcon notifyIcon, String title, String message)
		{
			notifyIcon.ShowBalloon(title, message, ToolTipIcon.None);
		}

		public static void ShowBalloon(this NotifyIcon notifyIcon, String title, String message, int milliseconds)
		{
			notifyIcon.ShowBalloon(title, message, ToolTipIcon.None, milliseconds);
		}

		public static void ShowBalloon(this NotifyIcon notifyIcon, String title, String message, ToolTipIcon icon)
		{
			notifyIcon.ShowBalloon(title, message, ToolTipIcon.Info, 30000);
		}

		public static void ShowBalloon(this NotifyIcon notifyIcon, String title, String message, ToolTipIcon icon, int milliseconds)
		{
			notifyIcon.BalloonTipTitle = title;
			notifyIcon.BalloonTipText = message;
			notifyIcon.BalloonTipIcon = icon;
			notifyIcon.ShowBalloonTip(milliseconds);
		}
    }
}
