#include <iostream>

using namespace std;

class TaxPayer
{
public:
	
	long PIN() const
	{
		return pin;
	}

	virtual double GetAnnualIncome() const = 0;

	double GetIncomeTax() const
	{
		double ex = GetAnnualIncome() - 120000;
		return ex > 0 ? 0.15 * ex : 0;
	}

	virtual ~TaxPayer(){}

protected:
	TaxPayer(long pn)
	{
		pin = pn;
	}

private:
	long pin;
};

void PrintInfo(const TaxPayer* t)
{
	cout << "P.I.N = " << t->PIN()
		 << ", Tax = " << t->GetIncomeTax()
		 << endl;
}

class Employee : public TaxPayer
{
public:
	explicit Employee(double sy, long pn=0) : TaxPayer(pn)
	{
		salary = sy;
	}

	double GetAnnualIncome() const
	{
		return 12 * salary + 20000;
	}
private:
	double salary;
};

class Dealer : public TaxPayer
{
public:
	Dealer(double ss, long pn=0) : TaxPayer(pn)
	{
		sales = ss;
	}

	double GetAnnualIncome() const
	{
		return 0.15 * sales;
	}
private:
	double sales;
};

class SalesPerson : public Employee, public Dealer
{
public:
	SalesPerson(double sy, double ss, long pn) : Employee(sy, pn), Dealer(ss, pn)
	{
	}

	double GetAnnualIncome() const
	{
		return Employee::GetAnnualIncome() - 20000 + Dealer::GetAnnualIncome() / 3;
	}
};

int main(void)
{
	Employee* jill = new Employee(24000, 123456);
	Dealer* jack = new Dealer(5400000, 234567);
	SalesPerson* john = new SalesPerson(15000, 2500000, 345678);

	cout << "Jill the Employee: ";
	PrintInfo(jill);
	cout << "Jack the Dealer: ";
	PrintInfo(jack);
	cout << "John the SalesPerson: ";
	PrintInfo(static_cast<Employee*>(john));
	
	delete john;
	delete jack;
	delete jill;
}

