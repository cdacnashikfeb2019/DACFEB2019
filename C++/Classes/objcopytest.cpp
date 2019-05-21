#include <iostream>

using namespace std;

class Interval
{
public:
	explicit Interval(long min=0, long sec=0)
	{
		minutes = min + sec / 60;
		seconds = sec % 60;
		cout << "Interval activated" << endl;
	}
	
	//copy constructor
	Interval(const Interval& that)
	{
		minutes = that.minutes;
		seconds = that.seconds;
		cout << "Interval copy activated" << endl;
	}

	void operator=(const Interval& that)
	{
		minutes = that.minutes;
		seconds = that.seconds;
		cout << "Interval assigned" << endl;
	}

	void SetTime(long value) 
	{
		minutes = value / 60;
		seconds = value % 60;
	}

	long GetTime() const
	{
		return 60 * minutes + seconds;
	}

	void Print() const
	{
		if(seconds < 10)
			cout << minutes << ":0" << seconds << endl;
		else
			cout << minutes << ":" << seconds << endl;
			
	}

	~Interval()
	{
		cout << "Interval deactivated" << endl;
	}
private:
	long minutes;
	long seconds;
};

class Journey
{
public:
	Journey(float dis, const Interval& dur) : duration(dur)
	{
		distance = dis;
		//duration = dur;
		cout << "Journey activated" << endl;
	}

	float Speed() const
	{
		return 3.6 * distance / duration.GetTime();
	}

	~Journey()
	{
		cout << "Journey deactivated" << endl;	
	}
private:
	float distance;
	Interval duration;
};

void Run()
{
	Interval a(3, 20);
	Journey b(500, a);
	cout << "Speed = " << b.Speed() << endl;
}

int main(void)
{
	cout << "Journey begins..." << endl;
	Run();
	cout << "Journey ends." << endl;
}


