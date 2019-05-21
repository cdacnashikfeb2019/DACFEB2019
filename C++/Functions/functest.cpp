#include <iostream>

using namespace std;

extern double Power(float, short);

int main(void)
{
	float b;
	short i;

	cout << "Enter base and index: ";
	cin >> b >> i;

	cout << "Result = "
		 << Power(b, i)
		 << endl;
}

