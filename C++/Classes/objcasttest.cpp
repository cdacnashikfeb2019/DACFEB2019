#include <iostream>

using namespace std;

class Interval
{
public:
	explicit Interval(long min=0, long sec=0)
	{
		minutes = min + sec / 60;
		seconds = sec % 60;
		id = 0;
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

	int GetId() const
	{
		static int nid = 1;
		if(id == 0)
			id = ++nid;
		return id;
	}

	static const Interval* Primary()
	{
		static Interval first;
		first.id = 1;
		return &first;
	}

private:
	long minutes;
	long seconds;
	mutable int id; //this field can change in const method
};

void Show(const Interval& i)
{
	cout << "Interval with ID " << i.GetId() << " is ";
	i.Print();
}

int main(void)
{
	Interval jack(3, 20);
	Show(jack);

	Interval jill(2, 30);
	Show(jill);

	const Interval* john = Interval::Primary();
	Interval* j = const_cast<Interval*>(john);
	j->SetTime(290);

	struct _Interval
	{
		long minutes;
		long seconds;
		int id;
	};

	_Interval* jj = reinterpret_cast<_Interval*>(j);
	jj->id = 100;

	Show(*john);
}


