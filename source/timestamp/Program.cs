using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace timestamp
{
	internal class Program
	{
		[STAThread]
		private static void Main(params string[] args)
		{
			if (Help(args))
			{
				return;
			}

			string format = "yyyyMMdd_HHmm";

			if (args.Length > 0)
			{
				format = args[0];
			}

			Output(format);

			DebugPause();
		}

		private static bool Help(string[] args)
		{
			string[] helpFlag = new string[] { "-?", "/?", "--help", "-help", "help" };

			if (args.Length == 1 && helpFlag.Any(s => args[0].Contains(s)))
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendLine("Predefined formats:");
				foreach (Template template in Predefined())
				{
					sb.AppendLine(template.ToString());
				}

				string help = string.Concat(
					"Usage:",
					Environment.NewLine,
					"timestamp [-f]",
					Environment.NewLine,
					"-f  .net DateTime format",
					Environment.NewLine,
					Environment.NewLine,
					sb.ToString());

				Console.WriteLine(help);

				DebugPause();

				return true;
			}

			return false;
		}

		private static IEnumerable<Template> Predefined()
		{
			yield return new Template("today", "dd-MM-yyyy");
			yield return new Template("today-iso", "yyyy-MM-dd");
			yield return new Template("today-us", "MM-yyyy-dd");
			yield return new Template("raw", "yyyyMMddHHmmss");
			yield return new Template("full", "dd-MM-yyyy_HH-mm-ss");
			yield return new Template("full-iso", "yyyy-MM-dd_HH-mm-ss");
			yield return new Template("full-us", "MM-yyyy-dd_HH-mm-ss");
		}

		private static void Output(string format)
		{
			try
			{
				string usedFormat = format;

				IEnumerable<Template> result;
				if ((result = Predefined().Where(t => t.ShortName == format)).Count() == 1)
				{
					usedFormat = result.Single().Format;
				}

				string dateFormated = DateTime.Now.ToString(usedFormat);
				Clipboard.SetText(dateFormated, TextDataFormat.Text);
				Console.WriteLine(dateFormated);
			}
			catch (Exception ex)
			{
				DisplayException(ex);
				return;
			}
		}

		private static void DisplayException(Exception exception)
		{
			if (Debugger.IsAttached)
			{
				Console.WriteLine(exception.ToString());
			}
			else
			{
				Console.WriteLine(exception.Message);
			}
		}

		private static void DebugPause()
		{
			if (Debugger.IsAttached)
			{
				Console.ReadLine();
			}
		}
	}

	internal class Template
	{
		public Template(string shortName, string format)
		{
			this.ShortName = shortName;
			this.Format = format;
		}

		public string ShortName
		{
			get;
			set;
		}

		public string Format
		{
			get;
			set;
		}

		public override string ToString()
		{
			return string.Format("{0}   {1}", this.ShortName, this.Format);
		}
	}
}