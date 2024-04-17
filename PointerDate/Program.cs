using System.Reflection;

Main();
unsafe void Main()
{
    MyDateTime mdt = new MyDateTime();
    MyDateTime* pointer = &mdt;
    Console.WriteLine(pointer->name);
    Console.WriteLine("The current date : {0:MM/dd/yy }", *(pointer->now));
    Console.WriteLine("The current date : {0:MM/dd/yy }", pointer->now2);
    Console.ReadLine();
}
unsafe struct MyDateTime
{
    public DateTime* now { get; set; }
    public DateTime now2 { get; set; }
    public String name { get; set; }
    public MyDateTime()
    {
        var td = DateTime.Now;
        now = &(td);
        now2 = td;
        var nowAddress = (long)&(td);
        Console.WriteLine("Address of now:{0}", nowAddress);
        Console.WriteLine("Date of now address:{0}", new DateTime(nowAddress));
        name = "today";
    }
}