using System;
using System.Reflection;

static class Program
{
	public static void Main()
	{
		Console.WriteLine("Welcome to our Shell");
		for(;;)
		{
			Console.Write("COMMAND: ");
			string cmd = Console.ReadLine();
			if(cmd.Length == 0) continue;
			if(cmd == "quit") break;
			try
			{
				Assembly asm = Assembly.LoadFrom($"commands\\{cmd}.exe");
				asm.EntryPoint.Invoke(null, null);
			}
			catch(Exception ex)
			{
				Console.WriteLine($"ERROR: {ex.Message}");
			}
			Console.WriteLine();
		}
		Console.WriteLine("Goodbye from our Shell");
	}
}
