using System;
using System.Collections.Generic;

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

	public IEnumerator<V> GetEnumerator()
	{
		for(Node n = top; n != null; n = n.Below)
			yield return n.Value;
	}
}

static class Program
{
	public static void Main()
	{
		int[] squares = {1, 9, 25, 49};
		Console.WriteLine("Numbers in squares");
		foreach(var n in squares)
			Console.WriteLine(n);

		SimpleStack<string> days = new SimpleStack<string>();
		days.Push("Monday");
		days.Push("Tuesday");
		days.Push("Wednesday");
		days.Push("Thursday");
		days.Push("Friday");
		Console.WriteLine("Strings in days");
		foreach(var d in days)
			Console.WriteLine(d);
		

	}
}
