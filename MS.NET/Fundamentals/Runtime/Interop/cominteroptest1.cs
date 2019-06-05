using System;
using System.Runtime.InteropServices;

static class Program
{
	public static void Main(string[] args)
	{
		double perim = double.Parse(args[0]);
		double area = double.Parse(args[1]);
		double a = 1, b = -perim / 2, c = area;

		//when new operator is applied to a COM imported class, it
		//activates the corresponding COM object and returns its RCW
		//which forwards managed calls to that COM object
		var qe = new QuadEq.QuadraticEquationClass(); 
	
		if(qe.HasRealRoots(a, b, c) != 0)
		{
			double r1, r2;
			qe.Solve(a, b, c, out r1, out r2);
			Console.WriteLine($"Dimensions = {r1}, {r2}");
		}
		else
			Console.WriteLine("No such rectangle!");
	}
}
