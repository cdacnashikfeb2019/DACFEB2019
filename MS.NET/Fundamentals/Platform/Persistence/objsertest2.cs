using HR;
using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Department));
		
		if(args.Length > 0)
		{
			Department dept = new Department {Title = args[0]};
			dept.AddEmployee(4, 45000);
			dept.AddEmployee(5, 53000);
			dept.AddEmployee(6, 67000);
			dept.AddEmployee(2, 23000);
			dept.AddEmployee(3, 32000);
			dept.AddEmployee(7, 76000);

			var doc = new FileStream("dept.xml", FileMode.Create);
			serializer.Serialize(doc, dept);
			doc.Close();
		}
		else
		{
			var doc = new FileStream("dept.xml", FileMode.Open);
			Department dept = (Department)serializer.Deserialize(doc);
			doc.Close();

			Console.WriteLine($"Employees of {dept.Title} department");
			foreach(Employee emp in dept.Employees)
				Console.WriteLine(emp);
		}
		
	}
}

