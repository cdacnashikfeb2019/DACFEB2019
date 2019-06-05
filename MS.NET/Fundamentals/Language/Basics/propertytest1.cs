using System;

struct Rectangle
{
	private int length;
	private int breadth;

	public Rectangle(int l, int b)
	{
		length = l;
		breadth = b;
	}

	//property - get/set methods which can be called using field access syntax
	public int Length
	{
		get
		{
			return length;
		}

		set
		{
			length = value;
		}
	}

	public int Breadth
	{
		get => breadth;
		set => breadth = value;
	}

	//read-only property
	public int Perimeter
	{
		get => 2 * (length + breadth);
	}

	//indexer - parameterized default (Item) property
	public int this[int thickness]
	{
		get => (length - 2 * thickness) * (breadth - 2 * thickness);
	}

}

static class Program
{
	public static void Main()
	{
		Rectangle r = new Rectangle(24, 18);
		Rectangle s = new Rectangle();
		s.Breadth = s.Length = 10; //s.set_Length(10)
		Console.WriteLine("Perimeter of first rectangle = {0}", r.Perimeter); //r.get_Perimeter()
		Console.WriteLine("Perimeter of second rectangle = {0}", s.Perimeter); //r.get_Perimeter()
		Console.WriteLine("Inner area of first rectangle = {0}", r[3]); //r.get_Item(3)
	}
}
