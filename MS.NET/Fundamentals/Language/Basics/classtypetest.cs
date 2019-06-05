using System;

enum RoomType {Economy, Business, Executive, Deluxe}

class HotelRoom
{
	public int Number;
	public RoomType Category;
	public bool Taken;

	public void Print()
	{
		string status = Taken ? "Occupied" : "Available";
		Console.WriteLine($"Room {Number} is of {Category} class and is currently {status}.");
	}
}

static class Program
{
	private static void Checkin(HotelRoom 
)
	{
		if(room.Taken)
			Console.WriteLine("Cannot check into an occupied room!");
		else
			room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom = new HotelRoom();
		myroom.Number = 504;
		myroom.Category = RoomType.Business;

		myroom.Print();
		Console.WriteLine("Checking into this room...");
		Checkin(myroom);
		myroom.Print();
	}
}