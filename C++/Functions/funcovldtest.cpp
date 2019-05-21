#include <iostream>
#include <cmath>

using namespace std;

double GetIncome(double invest, short years, float rate)
{
	double amount = invest * pow(1 + rate / 100, years);
	return amount - invest;
}

inline double GetIncome(double invest, short years)
{
	return GetIncome(invest, years, years < 3 ? 4 : 5);
}

int main(void)
{
	double p;
	short n;

	cout << "Enter investment and duration: ";
	cin >> p >> n;

	cout << "Income in fixed-deposit = "
		 << GetIncome(p, n, 6)
		 << endl;

	cout << "Income in savings-account = "
		 << GetIncome(p, n) //GetIncome(p, n, n < 3 ? 5 : 6)
		 << endl;
}

