<Query Kind="Program" />

void Main()
{
	PrintWord();
}

private unsafe void PrintWord()
{
	string s = "Привет";

	var sLength = s.Length;

	for (var i = 0; i < sLength; i++)
	{
		Console.WriteLine($"Values is {s[i]} ");
	}

	Console.WriteLine($"----------- ");

	//      2Б  2Б  2Б  2Б  2Б  2Б
	// p -> [П] [р] [и] [в] [е] [т]
	fixed (char* p = s)
	{

		char* p1 = &p[2];
		Console.WriteLine($"'{*p1}' - address current {(long)p1} next '{*(p1+1)}' {(long)(p1 + 1)}");

		for (var i = 0; i<sLength+100; i++) //for (var i = 0; p[i]!='\0'; i++) 
		{
			Console.WriteLine($"Values is '{p[i]}' memory address {(long)&p[i]}");
		}

	}
}