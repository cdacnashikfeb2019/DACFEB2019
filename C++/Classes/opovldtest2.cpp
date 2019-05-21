#include <iostream>

using namespace std;

class Interval
{
public:
	explicit Interval(long time=0)
	{
		seconds = time;
	}

	Interval(long min, long sec)
	{
		seconds = 60 * min + sec;
	}

	void SetTime(long value)
	{
		seconds = value;
	}

	long GetTime()
	{
		return seconds;
	}

	void Print()
	{
		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
			
	}
	
	long operator[](int index) const
	{
		return index ? (seconds / 60) : (seconds % 60);
	}

	operator float()
	{
		return seconds / 60.0;
	}
private:
	long seconds;
};

int main(void)
{
	Interval a(4, 45);
	a.Print();
	cout << "This Interval has " << a[1] << " minutes and "
		 << a[0] << " seconds." << endl;
	float b = a;
	cout << b << endl;
}


