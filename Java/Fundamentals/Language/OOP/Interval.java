class Interval{

	private int min, sec;

	public Interval(int m, int s){
		min = m + s / 60;
		sec = s % 60;
	}

	public int minutes(){
		return min;
	}

	public int seconds(){
		return sec;
	}

	public int time(){
		return min + 60 * sec;
	}

	public String toString(){
		return String.format("%d:%2d", min, sec);
	}

	public int hashCode(){
		return min + sec;
	}

	public boolean equals(Object other){
		if(other instanceof Interval){
			Interval that = (Interval)other;
			return (this.min == that.min) && (this.sec == that.sec);
		}
		return false;
	}
}

