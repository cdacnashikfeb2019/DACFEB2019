package edu.met.bkc.banking;

public interface Profitable{

	float MIN_RATE = 4;

	double getInterest(int months);

	default double getQuarterlyInterest(){
		return getInterest(3);
	}
}


