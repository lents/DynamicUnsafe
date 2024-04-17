<Query Kind="Program" />

void Main()
{
	unsafe
	{
		int* x; // определение указателя
		int y = 10; // определяем переменную

		x = &y; // указатель x теперь указывает на адрес переменной y

		// получим адрес переменной y
		ulong addr = (ulong)x;
		Console.WriteLine($"Адрес переменной y: {addr}");

		IntPtr ptr1 = new IntPtr(x);
		ptr1.Dump();
		ptr1.GetType().Dump();
		IntPtr.Size.Dump();
		IntPtr.MinValue.Dump();
		long.MinValue.Dump();
		IntPtr.MaxValue.Dump();
		long.MaxValue.Dump();
		x++; 
		IntPtr ptr2 = new IntPtr(x);
		ptr2.Dump();


	}
}

// You can define other methods, fields, classes and namespaces here