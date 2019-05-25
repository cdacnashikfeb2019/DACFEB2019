#include "interval.h"
#include <iostream>
#include <vector>
#include <queue>
#include <functional>

using namespace std;

int main(void)
{
	//priority_queue<Interval> store;
	priority_queue<Interval, vector<Interval>, greater<Interval> > store;
	store.push(Interval(5, 41));
	store.push(Interval(4, 52));
	store.push(Interval(6, 13));
	store.push(Interval(7, 34));
	store.push(Interval(3, 25));

	while(!store.empty())
	{
		cout << store.top() << endl;
		store.pop();
	}
}

