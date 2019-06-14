import payroll.*;

class SubclassTest2{

	private static double getAverageIncome(Employee[] group){
		double total = 0;
		for(Employee member : group){
			total += member.getIncome();
		}
		return total / group.length;
	}

	private static double getTotalSales(Employee[] group){
		double total = 0;
		for(Employee member : group){
			if(member instanceof SalesPerson){
				SalesPerson sp = (SalesPerson)member; //explicit narrowing
				total += sp.getSales();
			}
		}
		return total;
	}

	public static void main(String[] args){
		Employee[] department = new Employee[5];
		department[0] = new Employee(186, 52);
		department[1] = new Employee(175, 125);
		department[2] = new SalesPerson(165, 55, 45000); //implicit widening
		department[3] = new Employee(185, 205);
		department[4] = new SalesPerson(195, 65, 55000);
		System.out.printf("Average income: %.2f%n", getAverageIncome(department));
		System.out.printf("Total sales   : %.2f%n", getTotalSales(department));
	}

}

