#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetTotalSales(Employee* group[], int count)
{
	double total = 0;
	for(int i = 0; i < count; ++i)
	{
		SalesPerson* sp = dynamic_cast<SalesPerson*>(group[i]);
		if(sp)
			total += sp->GetSales();
	}
	return total;
}

int main(void)
{
	Employee* dept[5];
	dept[0] = new Employee(186, 52);
	dept[1] = new Employee(165, 95);
	dept[2] = new SalesPerson(178, 48, 38000);
	dept[3] = new Employee(190, 200);
	dept[4] = new SalesPerson(192, 52, 62000); 

	cout << "Total Sales: "
		 << GetTotalSales(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];

}

