#include <iostream>

using namespace std;

class Interval
{
public:
	//can be used as default or conversion or parametarized constructor.
	Interval(long sec=0, long min=0)
	{
		seconds = 60 * min + sec;
		++count;
	}

	void SetTime(long value)
	{
		seconds = value;
	}

	long GetTime()
	{
		return seconds;
	}

	//instance method - invoked on an object (using . operator)
	//receives 'this' argument which addresses the object on which it is invoked.
	void Print()
	{
		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}

	//static method - invoked on the class (using :: operator)
	//does not receive 'this' argument and as such it cannot refer to instance members
	static int CountInstances()
	{
		return count;
	}

	//destructor - automatically invoked during deactivation of object
	//stack-semantics: an object activated on the stack is deactivated 
	//immediately after it goes out of scope
	~Interval()
	{
		count--;
	}

private:
	long seconds; //instance field - each object stores a separate value of this field.
	static int count; //static field - all objects share a single value of this field.
};

int Interval::count = 0; //allocating value of static field.

void Run(void)
{
	Interval jeff(70, 3);
	cout << "Jeff's Interval activated" << endl;
	cout << "Jeff's Interval = ";
	jeff.Print();
	cout << "Jeff's Interval deactivated" << endl;
}

int main(void)
{
	Interval jack;
	cout << "Jack's Interval activated" << endl;
	jack.SetTime(125);
	cout << "Jack's Interval = ";
	jack.Print();

	Run();

	Interval john = 200; 
	cout << "John's Interval activated" << endl;
	cout << "John's Interval = ";
	john.Print();

	cout << "Number of active Intervals = " << Interval::CountInstances() << endl;

	cout << "John's Interval deactivated" << endl;
	cout << "Jack's Interval deactivated" << endl;

}


