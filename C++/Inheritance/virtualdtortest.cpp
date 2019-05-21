#define _TESTING
#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetAverageIncome(Employee* group[], int count)
{
	double total = 0;
	for(int i = 0; i < count; ++i)
	{
		total += group[i]->GetIncome();
	}
	return total / count;
}

int main(void)
{
	Employee* dept[5];
	dept[0] = new Employee(186, 52);
	cout << "----------------------------" << endl; 
	dept[1] = new Employee(165, 95);
	cout << "----------------------------" << endl; 
	dept[2] = new SalesPerson(178, 48, 38000); //implicit upcasting
	cout << "----------------------------" << endl; 
	dept[3] = new Employee(190, 200);
	cout << "----------------------------" << endl; 
	dept[4] = new SalesPerson(192, 52, 62000); 
	cout << "----------------------------" << endl; 

	cout << "Average Income: "
		 << GetAverageIncome(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];

}

