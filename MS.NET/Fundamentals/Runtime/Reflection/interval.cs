partial class Interval
{
	public int Minutes {get;}

	public int Seconds {get;}

	partial void OnInitialize();

	public Interval(int min, int sec)
	{
		Minutes = min + sec / 60;
		Seconds = sec % 60;
		OnInitialize();
	}

	public int GetTime() => 60 * Minutes + Seconds;

	public override string ToString()
	{
		return $"{Minutes}:{Seconds:00}";
	}

	public override int GetHashCode() => Minutes + Seconds;

	public override bool Equals(object other)
	{
		if(other is Interval that)
		{
			return (this.Minutes == that.Minutes) && (this.Seconds == that.Seconds);
		}

		return false;
	}

}


