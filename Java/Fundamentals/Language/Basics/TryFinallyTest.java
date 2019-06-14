class TryFinallyTest{
	
	private static void run(String[] args){
		System.out.println("Allocated resource.");
		try{
			double value = Double.parseDouble(args[0]);
			System.out.printf("Square = %.2f%n", value * value);
		}finally{
			System.out.println("Resource released.");
		}
	}

	public static void main(String[] args){
		System.out.println("Welcome user.");
		try{
			run(args);
		}catch(Exception e){
			System.out.println("Unknown input.");
		}
		System.out.println("Goodbye user.");
	}
}


