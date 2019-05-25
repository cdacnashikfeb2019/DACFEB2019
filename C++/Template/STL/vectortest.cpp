#include "interval.h"
#include <iostream>
#include <vector>

using namespace std;

int main(void)
{
	vector<Interval> store;
	store.push_back(Interval(5, 41));
	store.push_back(Interval(4, 52));
	store.push_back(Interval(6, 13));
	store.push_back(Interval(7, 34));
	store.push_back(Interval(3, 25));

	for(vector<Interval>::iterator i = store.begin(); i != store.end(); ++i)
		cout << *i << "\t" << i->GetTime() << endl;

	vector<Interval>::iterator j = store.begin();
	j += 3;
	cout << "Fourth Interval = " << *j << endl;

}

