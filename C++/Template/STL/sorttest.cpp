#include "interval.h"
#include <iostream>
#include <vector>
#include <functional>
#include <algorithm>

using namespace std;

bool IntervalComparison(const Interval& x, const Interval& y)
{
	long xs = x.GetTime() % 60;
	long ys = y.GetTime() % 60;
	return xs < ys;
}

int main(void)
{
	vector<Interval> store;
	store.push_back(Interval(5, 41));
	store.push_back(Interval(4, 52));
	store.push_back(Interval(6, 13));
	store.push_back(Interval(7, 34));
	store.push_back(Interval(3, 25));

	//sort(store.begin(), store.end());
	//sort(store.begin(), store.end(), greater<Interval>());
	sort(store.begin(), store.end(), IntervalComparison);

	for(vector<Interval>::iterator i = store.begin(); i != store.end(); ++i)
		cout << *i << "\t" << i->GetTime() << endl;
}

