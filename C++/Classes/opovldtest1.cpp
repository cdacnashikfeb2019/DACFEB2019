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

	Interval operator+(const Interval& other) const
	{
		return Interval(seconds + other.seconds);
	}

	Interval operator++() 
	{
		return Interval(++seconds);
	}

	Interval operator++(int)
	{
		return Interval(seconds++);
	}
private:
	long seconds;

	//non-member function of a class defined by the author of the class 
	//and as such has access to its private members
	friend Interval operator*(long, const Interval&);
};

Interval operator*(long lhs, const Interval& rhs)
{
	return Interval(lhs * rhs.seconds);
}

int main(void)
{
	Interval a(4, 30);
	a.Print();

	Interval b(3, 45);
	b.Print();

	Interval c = a + b; //a.operator+(b)
	c.Print();

	Interval d = 3 * a; //operator*(3, a)
	d.Print();

	Interval e = ++a;
	a.Print();
	e.Print();

	Interval f = b++;
	b.Print();
	f.Print();
}


