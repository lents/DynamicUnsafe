<Query Kind="Program" />

unsafe void  Main()
{
		int* x; // определение указателя
		int y = 10; // определяем переменную

		x = &y; // указатель x теперь указывает на адрес переменной y
		int** z = &x; // указатель z теперь указывает на адрес, указателя x
		**z = **z + 40; // изменение указателя z повлечет изменение переменной y
		Console.WriteLine(y); // переменная y=50
		Console.WriteLine(**z); // переменная **z=50
}

// You can define other methods, fields, classes and namespaces here