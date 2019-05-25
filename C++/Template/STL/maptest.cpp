#include "interval.h"
#include <iostream>
#include <string>
#include <map>

using namespace std;

int main(int argc, char* argv[])
{
	map<string, Interval> store;
	store.insert(make_pair("monday", Interval(5, 41)));
	store.insert(make_pair("tuesday", Interval(4, 52)));
	store.insert(make_pair("wednesday", Interval(6, 13)));
	store.insert(make_pair("thursday", Interval(7, 34)));
	store.insert(make_pair("friday", Interval(3, 25)));
	store.insert(make_pair("tuesday", Interval(2, 30)));

	if(argc == 1)
	{
		for(map<string, Interval>::iterator i = store.begin(); i != store.end(); ++i)
			cout << i->second << "\t" << i->first << endl;
	}
	else
	{
		string day = argv[1];
		map<string, Interval>::iterator j = store.find(day);
		if(j != store.end())
			cout << "Interval = " << j->second << endl;
		else
			cout << "Cannot find " << day << endl;
	}

}

