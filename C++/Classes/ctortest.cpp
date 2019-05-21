#include <iostream>

using namespace std;

class Interval
{
public:
	
	//default constructor - can be called with zero arguments.
	Interval()
	{
		seconds = 0;
	}

	//conversion constructor - can be called with one argument.
	Interval(long time)
	{
		seconds = time;
	}

	//parametarized constructor - can be called with multiple arguments.
	Interval(long sec, long min)
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
private:
	long seconds;
};


int main(void)
{
	Interval jack; //activation using default constructor.
	jack.SetTime(125);
	cout << "Jack's Interval = ";
	jack.Print();

	Interval john = 200; //activation using conversion constructor. 
	cout << "John's Interval = ";
	john.Print();

	Interval jeff(70, 3); //activation using parametarized constructor.
	cout << "Jeff's Interval = ";
	jeff.Print();
}


