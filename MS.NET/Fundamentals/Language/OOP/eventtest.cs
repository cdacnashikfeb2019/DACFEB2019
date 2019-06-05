using System;

class QuoteEventArgs : EventArgs
{
	public double CurrentValue{get;}

	public QuoteEventArgs(double value) => CurrentValue = value;
}

delegate void QuoteEventHandler(object sender, QuoteEventArgs e);

//quote event source
class Publisher
{
	public event QuoteEventHandler Available;

	private static Random generator = new Random();

	public void Publish(int count)
	{
		for(int i = 1; i <= count; ++i)
		{
			for(int t = Environment.TickCount + 1000 * i; t > Environment.TickCount;);
			double val = 0.01 * generator.Next(1000, 10000);
			Available?.Invoke(this, new QuoteEventArgs(val)); //raising the event
		}
	}
}

//quote event sink
class Subscriber
{
	private Publisher pub = new Publisher();

	public event QuoteEventHandler Arrived
	{
		add => pub.Available += value;
		remove => pub.Available -= value;
	}

	public Subscriber()
	{
		pub.Available += QuoteArrived;
		this.Arrived += ShowTime;
	}

	private void QuoteArrived(object sender, QuoteEventArgs e)
	{
		Console.WriteLine($"New price is {e.CurrentValue}");
	}

	//contravariant substitution for second parameter with respect to QuoteEventHandler delegate
	private void ShowTime(object sender, EventArgs e)
	{
		Console.WriteLine(DateTime.Now);
	}

	public void Start() => pub.Publish(5);
		
}


static class Program
{
	public static void Main()
	{
		Subscriber sub = new Subscriber();
		sub.Start();
	}
}
