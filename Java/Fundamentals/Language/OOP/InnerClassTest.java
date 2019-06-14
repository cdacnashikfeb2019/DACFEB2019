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


class InnerClassTest{

	//nested(static) member class
	//can only refer to static members of outer class
	//can define static as well as non-static members
	static class OddFilter implements Filter{
		public boolean allowed(int i){
			return (i % 2) == 1;
		}
	}

	//inner member class
	//can only define non-static members
	//can refer to static as well as non-static members of outer class
	class BigFilter implements Filter{
		private int limit;

		public BigFilter(int n){
			limit = n;
		}

		public boolean allowed(int i){
			return i > limit;
		}
	}

	public static void main(String[] args){
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
		System.out.print("All squares:");
		for(int n : squares)
			System.out.printf(" %d", n);
		System.out.println();
		System.out.printf("Number of odd squares = %d%n", Counter.countIf(squares, new InnerClassTest.OddFilter()));
		System.out.printf("Number of big squares = %d%n", Counter.countIf(squares, new InnerClassTest().new BigFilter(50)));
		int m = 25; //effectively final since it is referenced in inner local class
		//passing object of an inner local anonymous class
		System.out.printf("Number of small squares = %d%n", Counter.countIf(squares, new Filter(){
			public boolean allowed(int i){
				return i < m;
			}
		}));
	}
}

