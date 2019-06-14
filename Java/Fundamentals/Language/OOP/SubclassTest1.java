import payroll.Employee;
import payroll.SalesPerson;

class SubclassTest1{

	private static double getIncomeTax(Employee emp){
		double i = emp.getIncome();
		return i > 10000 ? 0.15 * (i - 10000) : 0;
	}

	public static void main(String[] args){
		Employee jack = new Employee();
		jack.setHours(52);
		jack.setRate(186);
		SalesPerson jill = new SalesPerson(52, 186, 48000);
		System.out.printf("Jack's ID is %d, Income is %.2f and Tax is %.2f%n", jack.getId(), jack.getIncome(), getIncomeTax(jack));
		System.out.printf("Jill's ID is %d, Income is %.2f and Tax is %.2f%n", jill.getId(), jill.getIncome(), getIncomeTax(jill));
		System.out.printf("Number of Employees = %d%n", Employee.countInstances());
	}
}

