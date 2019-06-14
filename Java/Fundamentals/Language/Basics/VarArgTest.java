class VarArgTest{
	
	public static double average(double first, double second){
		return (first + second) / 2;
	}

	public static double average(double first, double second, double third){
		return (first + second + third) / 3;
	}

	//public static double average(double first, double second, double third, double[] other){
	
	public static double average(double first, double second, double third, double... other){
		double sum = first + second + third;

		for(double value : other){
			sum += value;
		}

		return sum / (3 + other.length);
	}

	public static void main(String[] args){
		System.out.printf("Average = %.2f%n", average(7, 8));	
		System.out.printf("Average = %.2f%n", average(7, 8, 4));

		/*
		double[] other = {5, 6};
		System.out.printf("Average = %.2f%n", average(7, 8, 4, other));	
		*/

		System.out.printf("Average = %.2f%n", average(7, 8, 4, 5, 6, 9));	
		//System.out.printf("Average = %.2f%n", average(7, 8, 4, new double[]{5, 6, 9}));	
	}

}







