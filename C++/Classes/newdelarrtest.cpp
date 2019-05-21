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

int main(void)
{
	int n;
	cout << "Enter number of Intervals: ";
	cin >> n;

	Interval* store = new Interval[n];
	for(int i = 0; i < n; ++i)
	{
		store[i].SetTime(100 + 20 * i);
		store[i].Print();
	}
	delete[] store;
}


