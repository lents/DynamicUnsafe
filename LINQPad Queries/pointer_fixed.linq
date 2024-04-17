<Query Kind="Program" />

void Main()
{
	Move();
}

private void Move()
{
	var a = new int[5] { 10, 20, 30, 40, 50 };

	unsafe
	{
		fixed (int* p = &a[0])
		{


			int* p2 = p;
			Console.WriteLine(*p2);

			p2 += 1;
			Console.WriteLine(*p2);
			p2 += 1;
			Console.WriteLine(*p2);
			Console.WriteLine("--------");
			Console.WriteLine(*p);
			//p++;

			*p += 1;
			Console.WriteLine(*p);
			*p += 1;
			Console.WriteLine(*p);
		}
	}

	Console.WriteLine("--------");
	Console.WriteLine(a[0]);
}