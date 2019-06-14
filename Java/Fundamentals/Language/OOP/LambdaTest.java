//functional interface - contains exactly one abstract method
interface Filter{
	boolean allowed(int i);
}

class Counter{

	public static int countIf(int[] values, Filter check){
		int count = 0;
		for(int value : values){
			if(check.allowed(value))
				count += 1;
		}
		return count;
	}
}


class LambdaTest{

	private static boolean isOdd(int i){
		return (i % 2) == 1;
	}

	public static void main(String[] args){
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
		System.out.print("All squares:");
		for(int n : squares)
			System.out.printf(" %d", n);
		System.out.println();
		//passing method reference
		System.out.printf("Number of odd squares = %d%n", Counter.countIf(squares, LambdaTest::isOdd));
		int m = 50; //effectively final
		//passing lamda expression
		System.out.printf("Number of big squares = %d%n", Counter.countIf(squares, i -> i > m));
	}
}

