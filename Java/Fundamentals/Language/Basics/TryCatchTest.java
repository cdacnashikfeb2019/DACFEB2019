class TryCatchTest{
	
	private static void run(String[] args){
		try{
			double value = Double.parseDouble(args[0]);
			System.out.printf("Square = %.2f%n", value * value);
		}catch(ArrayIndexOutOfBoundsException e){
			System.out.println("No Input");
		}catch(NumberFormatException e){
			System.out.println(e.getMessage());	
		}
	}

	public static void main(String[] args){
		System.out.println("Welcome user.");
		run(args);
		System.out.println("Goodbye user.");
	}
}


