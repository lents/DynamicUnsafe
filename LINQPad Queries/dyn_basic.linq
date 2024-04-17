<Query Kind="Program" />

void Main()
{
	BasicDemo();
}

private void BasicDemo()
{
	dynamic s = 2d;

	Console.WriteLine($"Type={s.GetType()}, value={s}");
	//var f = s / 2;
	Console.WriteLine($"s + 2 = {s + 2}");

	s = new Bar("I'm Text");
	Console.WriteLine($"s = {s}");

    var v8 = V8(); 
	//Console.WriteLine($"{v8.Engine}");// Ошибка
	Console.WriteLine($"{((Car)v8).Engine}");
	//dynamic v8 = V8();
	//Console.WriteLine($"{v8.Engine}");
}

class Bar
{
	public Bar(string t)
		=> _text = t;

	private string _text;

	public override string ToString()
	=> $"{{Text: \"{_text}\"}}";
}

interface IVehicle { }

class Car : IVehicle
{
	public string Engine;
}

private IVehicle V8() => new Car { Engine = "V8" };