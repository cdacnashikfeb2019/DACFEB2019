using System;

class ResourceConsumer : IDisposable
{
	private static int count;
	private string id;

	static ResourceConsumer()
	{
		count = 0;
		#if TESTING
		Console.WriteLine($"ResourceConsumer type initialized in domain<{AppDomain.CurrentDomain.Id}>");
		#endif
	}

	public ResourceConsumer(string name)
	{
		id = name;
		++count;
		#if TESTING
		Console.WriteLine($"{id} resource acquired and its consumer<{count}> initialized");
		#endif
	}

	public void Consume(int cmd)
	{
		Console.WriteLine($"{id} resource consumed with action<{cmd}> in domain<{AppDomain.CurrentDomain.Id}>");
	}

	public void Dispose()
	{
		#if TESTING
		Console.WriteLine($"{id} resource released and its consumer disposed");
		#endif
		GC.SuppressFinalize(this);
	}

	//overriding Finalize method of System.Object
	~ResourceConsumer()
	{
		#if TESTING
		Console.WriteLine($"{id} resource released and its consumer finalized");
		#endif
	}
}


static class Program
{
	private static void Run()
	{
		var b = new ResourceConsumer("Second");
		b.Consume(102);
	}

	private static void Run(string arg)
	{
		/*
		var e = new ResourceConsumer("Fifth");
		try
		{
			e.Consume(int.Parse(arg));
		}
		finally
		{
			e.Dispose();
		}
		*/
		using(var e = new ResourceConsumer("Fifth"))
		{
			e.Consume(int.Parse(arg));
		}
	}

	public static void Main(string[] args)
	{
		var a = new ResourceConsumer("First");
		Run();
		GC.Collect(); //forcing garbage-collection
		a.Consume(101);

		AppDomain dom = AppDomain.CreateDomain("secondary");
		dom.DoCallBack(delegate()
		{
			var c = new ResourceConsumer("Third");
			c.Consume(103);
			var d = new ResourceConsumer("Fourth");
			d.Consume(104);
			d.Dispose();
		});
		AppDomain.Unload(dom);

		try
		{
			Run(args[0]);
		}
		catch {}

		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
	}
}
