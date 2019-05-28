using System;

class Interval
{
	public int Minutes {get;}

	public int Seconds {get;}

	public Interval(int min, int sec)
	{
		Minutes = min + sec / 60;
		Seconds = sec % 60;
	}

	public int Time => 60 * Minutes + Seconds;

	public void Print()
	{
		Console.WriteLine($"{Minutes}:{Seconds:00}");
	}

	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.Minutes + rhs.Minutes, lhs.Seconds + rhs.Seconds);
	}

	public static Interval operator*(int lhs, Interval rhs)
	{
		return new Interval(lhs * rhs.Minutes, lhs * rhs.Seconds);
	}

	public static Interval operator++(Interval val)
	{
		return new Interval(val.Minutes, val.Seconds + 1);
	}

	//public static implicit operator double(Interval val)
	public static explicit operator double(Interval val)
	{
		return val.Minutes + val.Seconds / 60.0;
	}
}

static class Program
{
	public static void Main()
	{
		Interval a = new Interval(5, 45);
		a.Print();

		Interval b = new Interval(3, 20);
		b.Print();

		Interval c = a + b;
		c.Print();
		
		Interval d = 3 * a;
		d.Print();

		//Interval e = ++b;
		Interval e = b++;
		b.Print();
		e.Print();

		double f = (double)a;
		Console.WriteLine(f);
	}
}
