namespace Greeting
{
	public class Greeter
	{
		public string Greet(string name, bool formal)
		{
			if(formal)
				return "Hello " + name;
			return "Hi " + name;
		}
	}
}
