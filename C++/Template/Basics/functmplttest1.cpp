#include <iostream>
#include <string>

using namespace std;

/*
void Swap(double& first, double& second)
{
	double third = first;
	first = second;
	second = third;
}

void Swap(string& first, string& second)
{
	string third = first;
	first = second;
	second = third;
}
*/

template<typename T>
void Swap(T& first, T& second) //Swap function template with type parameter T
{
	T third = first;
	first = second;
	second = third;
}
int main(void)
{
	double dx = 12.3, dy = 13.2;
	cout << "Original double values: " << dx << ", " << dy << endl;
	Swap<double>(dx, dy); //calling templated Swap function with T=double
	cout << "Swapped double values: " << dx << ", " << dy << endl;

	string sx = "Monday", sy = "Tuesday";
	cout << "Original string values: " << sx << ", " << sy << endl;
	Swap(sx, sy); //Swap<string>(sx, sy) - type inference from arguments
	cout << "Swapped string values: " << sx << ", " << sy << endl;

	//Swap(sx, dx);
}

