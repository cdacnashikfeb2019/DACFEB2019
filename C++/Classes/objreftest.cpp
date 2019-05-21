#include <iostream>

using namespace std;

class Interval
{
public:
	Interval(long sec=0, long min=0)
	{
		seconds = 60 * min + sec;
		++count;
	}

	void SetTime(long value)
	{
		seconds = value;
	}

	long GetTime() const //long _ZNK8Interval7GetTimeEv(const Interval* this)
	{
		return seconds; //this->seconds
	}

	void Print() const
	{
		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}

	static int CountInstances()
	{
		return count;
	}

	~Interval()
	{
		count--;
	}

private:
	long seconds; 
	static int count;
};

int Interval::count = 0;

float Speed(float distance, const Interval& duration)
{
	return 3.6 * distance / duration.GetTime(); //_ZNK8Interval7GetTimeEv(&duration)
}

int main(void)
{
	Interval jack(125);
	Interval john(20, 3); 

	cout << "Jack's speed = " << Speed(500, jack) << endl;
	cout << "John's speed = " << Speed(500, john) << endl;

	cout << "Number of active Intervals = " << Interval::CountInstances() << endl;
}


