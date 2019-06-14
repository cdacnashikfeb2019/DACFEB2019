enum RoomType{ECONOMY, BUSINESS, EXECUTIVE, DELUXE}

class SwitchEnumTest{
	
	public static double getRent(int stay, RoomType room){
		float rate = 0;
		
		switch(room){
		case ECONOMY: 
			rate = 750;
			break;

		case BUSINESS:
			rate = 900;
			break;

		case EXECUTIVE:
			rate = 1200;
			break;

		case DELUXE:
			rate = 1500;
		}
	
		return 1.06 * stay * rate;
	}

	public static void main(String[] args){
		int stay = Integer.parseInt(args[0]);

		System.out.printf("Rent for ECONOMY room type = %.2f%n", getRent(stay, RoomType.ECONOMY));
		System.out.printf("Rent for BUSINESS room type = %.2f%n", getRent(stay, RoomType.BUSINESS));
		System.out.printf("Rent for EXECUTIVE room type = %.2f%n", getRent(stay, RoomType.EXECUTIVE));
		System.out.printf("Rent for DELUXE room type = %.2f%n", getRent(stay, RoomType.DELUXE));
	
	}	
}



