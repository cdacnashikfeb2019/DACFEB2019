using System;
using System.Text;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport(@"legacy\x86\hashenc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode)]
	private extern static int HashOfString(string str);

	[DllImport(@"legacy\x86\hashenc.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Ansi)]
	private extern static int EncodeBuffer(StringBuilder buf, int sz);


	public static void Main(string[] args)
	{
		Console.WriteLine("Original string = {0}", args[0]);
		Console.WriteLine("Hash of string  = {0:X}", HashOfString(args[0]));
		StringBuilder sb = new StringBuilder(args[0]);
		EncodeBuffer(sb, sb.Length);
		Console.WriteLine("Encoded string  = {0}", sb);
	}
}