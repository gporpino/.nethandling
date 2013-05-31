using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using MapfreConnectionsManager.Classes;
using PorpinoHandling.ExtensionsMethod;
using System.Threading;

namespace PorpinoHandling
{
	public class CommandManager
	{
		private static CommandManager instance = null;
		public static CommandManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new CommandManager();
				}
				return instance;
			}
		}

		public String ExecuteCommand(Command command, String arguments)
		{
			return ExecuteCommand(command, arguments, UserLevel.NORMAL);

		}

		public String ExecuteCommand(Command command, String arguments, UserLevel level)
		{
			Console.WriteLine(arguments);
			Process process = null;

			Task task = Task.Factory.StartNew(() => process = Execute(command, arguments, level));
			task.Wait();

			String error = process.StandardError.ReadToEnd();
			if (error != String.Empty)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("Erro ao executar o commando: ");
				sb.Append(command.Value() + " " + arguments);
				sb.Append(" Erro: ");
				sb.Append(error);
				throw new InvalidOperationException(sb.ToString());
			}

			return process.StandardOutput.ReadToEnd();
		}

		private Process Execute(Command Executable, String Arguments, UserLevel level)
		{
			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();

			startInfo.FileName = Executable.Value();
			startInfo.Arguments = Arguments;

			if (level == UserLevel.ADMIN)
			{
				startInfo.Verb = @"runas";
				startInfo.WindowStyle = ProcessWindowStyle.Normal;
			}
			else
			{
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				startInfo.UseShellExecute = false;
				startInfo.CreateNoWindow = true;
			}

			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardError = true;

			process.StartInfo = startInfo;
			process.Start();
			process.WaitForExit();

			return process;
		}
	}
}
