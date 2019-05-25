#include "interval.h"
#include <iostream>
#include <vector>
#include <list>
#include <algorithm>

using namespace std;

int main(void)
{
	list<Interval> store;
	store.push_back(Interval(5, 41));
	store.push_back(Interval(4, 52));
	store.push_back(Interval(6, 13));
	store.push_back(Interval(7, 34));
	store.push_back(Interval(3, 25));

	vector<Interval> temp(store.size());
	copy(store.begin(), store.end(), temp.begin());
	sort(temp.begin(), temp.end());
	copy(temp.begin(), temp.end(), store.begin());

	for(list<Interval>::iterator i = store.begin(); i != store.end(); ++i)
		cout << *i << "\t" << i->GetTime() << endl;
}

