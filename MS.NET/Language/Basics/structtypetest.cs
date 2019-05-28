using System;

enum RoomType {Economy, Business, Executive, Deluxe}

struct HotelRoom
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
	private static void Checkin(ref HotelRoom room)
	{
		if(room.Taken)
			Console.WriteLine("Cannot check into an occupied room!");
		else
			room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom;
		myroom.Number = 504;
		myroom.Category = RoomType.Business;
		myroom.Taken = false;

		myroom.Print();
		Console.WriteLine("Checking into this room...");
		Checkin(ref myroom);
		myroom.Print();
	}
}