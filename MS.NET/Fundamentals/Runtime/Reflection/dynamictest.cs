using System;

static class Program
{
	public static void Main(string[] args)
	{
		Type t = Type.GetType($"Greeters.{args[0]}Greeter,greeters");
		/*
		var g = Activator.CreateInstance(t);
		var meet = t.GetMethod("Meet", new[]{typeof(string)});
		Console.WriteLine(meet.Invoke(g, new object[]{"Jack"}));
		*/
		dynamic g = Activator.CreateInstance(t); //compiler generates DLR binding for members of g
		Console.WriteLine(g.Meet("Jack")); //duck typing
		Console.WriteLine(g.Leave("Jack"));
		//Console.WriteLine(g.Kick("Jack"));
	}
}
