using Nanook.QueenBee.Parser;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

internal static class Program
{
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool AllocConsole();
	// crust to not go back and forth
	// changing from console to form app

	/*public static string abspath(string f)
	{
		return Path.IsPathRooted(f) ? f : Directory.GetCurrentDirectory() + '\\' + f;
	}*/
	public static string folder;
	// whatever
	public static string[] args;
	public static bool a_log;
	//public static List<string> loadingfiles;
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main(string[] _args)
	{
		folder = Path.GetDirectoryName(Application.ExecutablePath) + '\\';
		if (File.Exists(folder + "names.txt"))
			foreach (string n in File.ReadAllLines(folder + "names.txt"))
			{
				try
				{
					DebugNames.Add(Convert.ToUInt32(n.Substring(0, 8), 16), n.Substring(9));
				}
				catch { }
			}
		args = _args;
		//loadingfiles = new List<string>();
		/*for (int i = 0; i < args.Length; i++)
		{
			if (File.Exists(args[i]))
				loadingfiles.Add(args[i]);
			else
			{
				if (args[i].ToLower() != "-l")// &&
					//args[i].ToLower() != "-h")
					Console.WriteLine("Invalid file name.");
				args[i] = args[i].ToLower(); // weird
			}
		}*/
		a_log = Array.IndexOf(args, "-l") != -1;
		//bool a_help = Array.IndexOf(args, "-h") != -1;
		if (a_log/* || a_help*/)
		{
			AllocConsole();
			Console.OpenStandardOutput();
		}
		/*if (a_help)
		{
			// TODO: support building zones automatically?
			Console.WriteLine("MuhZones - donnaken15\nGH3 Texture Mod Tool");
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
			Environment.Exit(0);
		}*/
		
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new main1());
	}

	public static void loadtext(string a)
	{
		if (!a_log) return;
		int cccc = Console.CursorTop;
		Console.SetCursorPosition(0, Console.CursorTop);
		Console.Write(new string(' ', Console.WindowWidth));
		Console.SetCursorPosition(0, cccc);
		Console.Write(a);
	}

	public static Dictionary<uint, string> DebugNames = new Dictionary<uint, string>();
	public static string GetDebugName(QbKey key)
	{
		return GetDebugName(key.Crc);
	}
	public static string GetDebugName(uint key)
	{
		try
		{
			return DebugNames[key];
		}
		catch
		{
			return key.ToString("X8");
		}
	}
	public static string GetDebugName(uint key, out bool success)
	{
		// success = got text
		try
		{
			string a = DebugNames[key];
			success = true;
			return a;
		}
		catch
		{
			success = false;
			return key.ToString("X8");
		}
	}
	public static QbKey keyWithDebug(uint key)
	{
		bool gottext = false;
		string dname = GetDebugName(key, out gottext);
		if (gottext)
			return QbKey.Create(key, dname);
		else
			return QbKey.Create(key);
	}
}
