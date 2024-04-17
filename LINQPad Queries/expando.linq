<Query Kind="Program">
  <Namespace>System.Dynamic</Namespace>
</Query>

using System.Dynamic;
void Main()
{
	var eo = new ExpandoObject();

	dynamic d = eo;

	eo.TryAdd("A", 2);
	eo.TryAdd("B", 5);
	eo.TryAdd("Foo", new Func<string>(() => $"Hello World!  A={d.A} B={d.B}"));
	//eo.Remove("A", out var f);
	Console.WriteLine(d.Foo());


    Console.WriteLine("=====================");
	var eo2 = new ExpandoObject();
	var dict = (IDictionary<string, object>)eo2;
	dict.Add("Field2Check", 2);
	if (dict.ContainsKey("Field2Check"))
	{
		Console.WriteLine("Has Field2Check");
	}

	dynamic d2 = eo2;
	Console.WriteLine($"{d2.Field2Check}");

}