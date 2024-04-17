<Query Kind="Program" />

void Main()
{
	ShowSwap();
}
unsafe void PSwap(int* a, int* b)
{
	int c = *a;
	*a = *b;
	*b = c;
}


private unsafe void ShowSwap()
{
	int a = 22, b = 3;
	PSwap(&a, &b);
	Console.WriteLine($"a={a} b={b}");

}