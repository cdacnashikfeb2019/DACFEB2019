#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetIncomeTax(const Employee& entry)
{
	double i = entry.GetIncome(); //an indirect call (on ptr or ref) to a virtual function
								  //is invoked through dynamic binding.
								  //entry.vt->GetIncome(&entry)
	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

int main(void)
{
	Employee jack;
	jack.SetHours(186);
	jack.SetRate(52);

	SalesPerson jill(186, 52, 48000);

	cout << "Jack's Income is "
		 << jack.GetIncome()
		 << " and Tax is "
		 << GetIncomeTax(jack)
		 << endl;
	cout << "Jill's Income is "
		 << jill.GetIncome()
		 << " and Tax is "
		 << GetIncomeTax(jill)
		 << endl;
}

