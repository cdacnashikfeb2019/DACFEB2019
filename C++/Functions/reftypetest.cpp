#include <iostream>

using namespace std;

void Swap(double& first, double& second)
{
	double third = first;
	first = second;
	second = third;
}

double Average(double first, double second, double& dev)
{
	dev = first > second ? (first - second) / 2 : (second - first) / 2;
	return (first + second) / 2;
}

int main(void)
{
	double x = 3.4, y = 4.3;

	cout << "Original values: " << x << ", " << y << endl;
	Swap(x, y);
	cout << "Swapped values: " << x << ", " << y << endl;

	double w;
	double z = Average(x, y, w);
	cout << "Average is " << z << " with a deviation of " << w << endl;
}


