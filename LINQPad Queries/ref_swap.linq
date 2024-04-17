<Query Kind="Program" />

void Main()
{
	ShowSwap();
	I a = new A() {i=6};
	Proccesor(ref a);
	
	a.Dump();
}

// You can define other methods, fields, classes and namespaces here
 void PSwap(ref int a, ref int b)
{
	int c = a;
	a = b;
	b = c;
}

void PSwapFake( int a, int b)
{
	int c = a;
	a = b;
	b = c;
}



private void ShowSwap()
{
	int a = 2, b = 3;
	PSwap(ref a, ref b);
	Console.WriteLine($"a={a} b={b}");
	PSwapFake(a, b);
	Console.WriteLine($"a={a} b={b}");
	PSwap(ref a, ref b);
	Console.WriteLine($"a={a} b={b}");
}

void Proccesor(ref I someobj)
{
	someobj= new B(){j=2, y=3};
}


interface I{}

class A : I
{
	public int i {get;set;}
}


class B : I
{
	public int j { get; set; }
	public int y { get; set; }
}