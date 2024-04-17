<Query Kind="Program" />

unsafe void Main()
{	
	MyDateTime mdt=new MyDateTime();
	MyDateTime* pointer =&mdt;
	Console.WriteLine(pointer->name);
	Console.WriteLine("The current date : {0:MM/dd/yy }",*(pointer->now));	
	Console.WriteLine("The current date : {0:MM/dd/yy }",pointer->now2);	
}
unsafe struct MyDateTime{
	public DateTime* now{get;set;}
	public DateTime now2{get;set;}
	public String name{get;set;}
	public MyDateTime(){
	    var td=DateTime.Today;	 
		now=&(td);
		now2=td;
		name="today";
	}
}