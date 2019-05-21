#include <iostream>

using namespace std;

class Interval
{
public:
	//cannot be used as conversion constructor
	explicit Interval(long min=0, long sec=0)
	{
		minutes = min + sec / 60;
		seconds = sec % 60;
		cout << "Interval activated" << endl;
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

inline float Speed(float distance, const Interval& duration)
{
	return 3.6 * distance / duration.GetTime();
}

int main(void)
{
	Interval* jack = new Interval; //dynamic activation using default constructor
	jack->SetTime(125);
	cout << "Jack's Interval = ";
	jack->Print();
	cout << "Jack's speed = " << Speed(500, *jack) << endl;
	delete jack; //explicit deactivation of dynamically activated object

	Interval* john = new Interval(3, 20); //dynamic activation using parametarized constructor
	cout << "John's Interval = ";
	john->Print();
	cout << "John's speed = " << Speed(500, *john) << endl;

	delete john;

}


