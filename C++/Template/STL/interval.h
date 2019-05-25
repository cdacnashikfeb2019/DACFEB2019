#ifndef INTERVAL_H
#define INTERVAL_H
#include <iostream>

class Interval
{
public:
	explicit Interval(long min=0, long sec=0)
	{
		minutes = min + sec / 60;
		seconds = sec % 60;
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

	bool operator==(const Interval& that) const
	{
		long t1 = 60 * minutes + seconds;
		long t2 = 60 * that.minutes + that.seconds;
		return t1 == t2;
	}

	bool operator<(const Interval& that) const
	{
		long t1 = 60 * minutes + seconds;
		long t2 = 60 * that.minutes + that.seconds;
		return t1 < t2;
	}

	bool operator>(const Interval& that) const
	{
		long t1 = 60 * minutes + seconds;
		long t2 = 60 * that.minutes + that.seconds;
		return t1 > t2;
	}

private:
	long minutes;
	long seconds;
	friend std::ostream& operator<<(std::ostream& out, const Interval& value);
};

std::ostream& operator<<(std::ostream& out, const Interval& value)
{
	if(value.seconds < 10)
		out << value.minutes << ":0" << value.seconds;
	else
		out << value.minutes << ":" << value.seconds;
	return out;
}

#endif
