<Query Kind="Program" />

void Main()
{
	ShowSimple();
}

private unsafe void ShowSimple()
{
	var first = 1;
	var second = 4;

	// Указатель на адрес памяти 
	// где содержится значение first
	int* p = &first;

	int* q = &second;

	// В адрес, куда указывает p записываем 2
	// (а там же - место где хранится переменная first)
	*p = 2;

	Console.WriteLine($"first = {first}");

	first = 555;

	Console.WriteLine($"*p = {*p}");
	// Присваиваем p - адрес в памяти
	// где хранится second 
	p = q;

	second = 5;
	first = 12412412;
	q = &first;
	Console.WriteLine($"*p = {*p}, first={first}, second={second}, *q={*q}");

}