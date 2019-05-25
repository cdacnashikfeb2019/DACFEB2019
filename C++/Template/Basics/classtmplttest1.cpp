#include "interval.h"
#include <iostream>
#include <string>

using namespace std;

template<typename I, typename V>
class IndexedValue //IndexedValue class template
{
public:
	IndexedValue(I id)
	{
		index = id;
	}

	V GetValue() const
	{
		return value;
	}

	void SetValue(const V& val)
	{
		value = val;
	}

	void Print() const
	{
		cout << "{" << index << "} = " << value << endl;
	}
private:
	I index;
	V value;
};

int main(void)
{
	IndexedValue<string, double> a("Monday"); //using templated IndexedValue class for I=string, V=double
	a.SetValue(12.3);
	a.Print();

	IndexedValue<int, string> b(1);
	b.SetValue("Jack");
	b.Print();

	IndexedValue<int, Interval> c(2);
	c.SetValue(Interval(3, 45));
	c.Print();
}

