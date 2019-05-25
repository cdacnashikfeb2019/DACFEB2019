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

template<>
class IndexedValue<string, bool> //full specialization of IndexedValue class template
{
public:
	IndexedValue(string i)
	{
		index = i;
	}

	bool GetValue() const
	{
		return value;
	}

	void SetValue(bool val)
	{
		value = val;
	}

	void Print() const
	{
		cout << "{" << index << "} = " << (value ? "true" : "false") << endl;
	}
private:
	string index;
	bool value;
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

	IndexedValue<string, bool> d("Tuesday");
	d.SetValue(true);
	d.Print();
}

