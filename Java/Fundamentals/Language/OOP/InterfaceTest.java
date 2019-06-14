import edu.met.bkc.banking.*;

class InterfaceTest{

	private static void payQuarterlyInterest(Account[] accounts){
		for(Account acc : accounts){
			if(acc instanceof Profitable){
				Profitable p = (Profitable)acc;
				double interest = p.getQuarterlyInterest();
				acc.deposit(interest);
			}
		}
	}

	public static void main(String[] args){
		Account[] bank = new Account[4];
		bank[0] = Banker.openSavingsAccount();
		bank[0].deposit(5000);
		bank[1] = Banker.openCurrentAccount();
		bank[1].deposit(20000);
		bank[2] = Banker.openCurrentAccount();
		bank[2].deposit(30000);
		bank[3] = Banker.openSavingsAccount();
		bank[3].deposit(35000);
		payQuarterlyInterest(bank);
		for(Account acc : bank)
			System.out.printf("%d\t%.2f%n", acc.getId(), acc.getBalance());
	}
}

