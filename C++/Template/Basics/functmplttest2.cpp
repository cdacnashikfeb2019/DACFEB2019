#include "interval.h"
#include <iostream>
#include <string>

using namespace std;

int nid = 0;

template<typename Any>
void PrintWithIndex(Any value)
{
	cout << "[" << (++nid) << "] = " << value << endl;
}

template<>
void PrintWithIndex(bool value) //explicit specialization of PrintWithIndex function template for Any=bool
{
	cout << "[" << (++nid) << "] = " << (value ? "true" : "false") << endl;	
}

int main(void)
{
	double a = 12.3;
	PrintWithIndex(a);

	string b = "Monday";
	PrintWithIndex(b);

	string c = "Tuesday";
	PrintWithIndex(c);

	bool d = true;
	PrintWithIndex(d);

	Interval e(3, 45);
	PrintWithIndex(e);
}

