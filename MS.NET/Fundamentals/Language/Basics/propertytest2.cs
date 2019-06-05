using System;

class Customer
{
	//auto property
	public string Name {get; set;}

	//auto property with initializer
	public decimal Credit {get; set;} = 5000;
}

static class Program
{
	public static void Main()
	{
		Customer a = new Customer();
		a.Name = "Jack";
		a.Credit = 4000;
		Console.WriteLine($"{a.Name}'s credit is {a.Credit}");
		
		//object initializer
		Customer b = new Customer {Name = "Jill", Credit = 6000};
		Console.WriteLine($"{b.Name}'s credit is {b.Credit}");
		
		//implicitly typed local (type will be inferred from the initializer)
		var c = new Customer {Name = "John"};
		Console.WriteLine($"{c.Name}'s credit is {c.Credit}");

		//anonymous type
		var d = new {Id = 12, Score = 60.5};
		Console.WriteLine($"Student with ID {d.Id} has scored {d.Score}");

		//reusing anonymous type
		var e = new {Id = 21, Score = 50.5};
		Console.WriteLine($"Student with ID {e.Id} has scored {e.Score}");

	}
}
