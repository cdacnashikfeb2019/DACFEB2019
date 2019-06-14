package edu.met.bkc.banking;

public class Banker{

	private static long nid = System.currentTimeMillis() % 1000000;

	private Banker(){}

	public static Account openCurrentAccount(){
		Account acc = new CurrentAccount();
		acc.id += 10000000L + nid++;
		return acc;
	}

	public static Account openSavingsAccount(){
		Account acc = new SavingsAccount();
		acc.id += 20000000L + nid++;
		return acc;
	}
}


