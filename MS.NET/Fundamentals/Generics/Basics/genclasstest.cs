using System;

class SimpleStack<V>
{
	class Node
	{
		internal V Value;
		internal Node Below;
	}

	private Node top;

	public void Push(V value)
	{
		top = new Node{Value = value, Below = top};
	}

	public V Pop()
	{
		Node node = top;
		top = top.Below;
		return node.Value;
	}

	public bool Empty() => top == null;
}

static class Program
{
	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");
		//a.Push(12.3);

		SimpleStack<string> b = new SimpleStack<string>();
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");

		SimpleStack<Interval> c = new SimpleStack<Interval>();
		c.Push(new Interval(5, 31));
		c.Push(new Interval(4, 52));
		c.Push(new Interval(7, 23));
		c.Push(new Interval(3, 44));
		c.Push(new Interval(6, 15));

		SimpleStack<object> d = new SimpleStack<object>();
		d.Push("Sunday");
		d.Push(new Interval(2, 30));
		d.Push(12.3);

		while(!a.Empty())
			Console.WriteLine(a.Pop());
		Console.WriteLine("-------------------------");
		while(!b.Empty())
			Console.WriteLine(b.Pop());
		Console.WriteLine("-------------------------");
		while(!c.Empty())
			Console.WriteLine(c.Pop());
		Console.WriteLine("-------------------------");
		while(!d.Empty())
			Console.WriteLine(d.Pop());


	}
}
