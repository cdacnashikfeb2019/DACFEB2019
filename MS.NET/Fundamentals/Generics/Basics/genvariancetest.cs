using System;

interface IStackReader<out T>
{
	T Pop();
	bool Empty();
}

interface IStackWriter<in T>
{
	void Push(T value);
}

class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
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

	public void Copy(IStackWriter<V> target)
	{
		for(Node n = top; n != null; n = n.Below)
			target.Push(n.Value);
	}
}

class FiniteStack<V> : IStackReader<V>, IStackWriter<V>
{
	private V[] values;
	private int count;

	public FiniteStack(int size)
	{
		values = new V[size];
	}

	public void Push(V value)
	{
		values[count++] = value;
	}

	public V Pop()
	{
		return values[--count];
	}

	public bool Empty() => count == 0;
}

static class Program
{
	private static void PrintStack(IStackReader<object> stack)
	{
		for(int count = 0; !stack.Empty(); ++count)
		{
			if(count > 0)
				Console.Write(", ");
			Console.Write(stack.Pop());
		}
		Console.WriteLine();
	}

	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");

		FiniteStack<string> b = new FiniteStack<string>(12);
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

		a.Copy(b);
		c.Copy(d);

		PrintStack(a);
		PrintStack(b);
		PrintStack(c);
		PrintStack(d);
	}
}
