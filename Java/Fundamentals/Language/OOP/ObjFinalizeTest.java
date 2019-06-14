class ResourceConsumer implements AutoCloseable{

	private String id;

	static{
		System.out.println("ResourceConsumer class initialized");
	}

	public ResourceConsumer(String name){
		id = name;
		System.out.printf("%s resource acquired and its consumer initialized%n", id);
	}

	public void consume(int cmd){
		System.out.printf("%s resource consumed with action<%s>%n", id, cmd);
	}

	public void close(){
		System.out.printf("%s resource released and its consumer closed%n", id);
		id = null;
	}

	public void finalize(){
		if(id != null)
			System.out.printf("%s resource released and its consumer finalized%n", id);
	}
}


class ObjFinalizeTest{

	private static void run(){
		ResourceConsumer b = new ResourceConsumer("Second");
		b.consume(202);
	}

	private static void run(String arg){
		/*
		ResourceConsumer d = new ResourceConsumer("Fourth");
		try{
			d.consume(Integer.parseInt(arg));
		}finally{
			d.close();
		}
		*/
		try(ResourceConsumer d = new ResourceConsumer("Fourth")){
			d.consume(Integer.parseInt(arg));	
		}
	}

	public static void main(String[] args){
		ResourceConsumer a = new ResourceConsumer("First");
		run();
		System.gc(); //request garbage-collection
		a.consume(101);
		ResourceConsumer c = new ResourceConsumer("Third");
		c.consume(303);
		c.close();
		try{
			run(args[0]);
		}catch(Throwable t){}
	}
}

