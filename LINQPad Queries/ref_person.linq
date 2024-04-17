<Query Kind="Program" />

void Main()
{
	Person p = new Person { name = "Tom", age = 23 };
	ChangePerson(ref p);

	Console.WriteLine(p.name); // Bill
	Console.WriteLine(p.age); // 45
}



void ChangePerson(ref Person person)
{
	// сработает
	person.name = "Alice";
	// сработает
	person = new Person { name = "Bill", age = 45 };
}

class Person
{
	public string name = "";
	public int age;
}