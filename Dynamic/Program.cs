using System.Dynamic;

//ExampleExpandoObejct();
ExampleDynamicObject();

void ExampleExpandoObejct()
{
    dynamic person = new ExpandoObject();

    // Adding properties dynamically
    person.Name = "John";
    person.Age = 30;
    person.IsMarried = false;

    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Married: {person.IsMarried}");

    // Modifying properties dynamically
    person.Age = 35;
    person.IsMarried = true;

    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Married: {person.IsMarried}");

    // Adding methods dynamically
    ((Action)(() => Console.WriteLine("Hello, I'm " + person.Name)))();

    // Removing a property dynamically
    ((IDictionary<string, object>)person).Remove("IsMarried");

    // Trying to access the removed property will throw a runtime exception
    try
    {
        Console.WriteLine($"Married: {person.IsMarried}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


void ExampleDynamicObject() {
    dynamic dynamicObject = new CustomDynamicObject();

    // Adding properties dynamically
    dynamicObject.Name = "John";
    dynamicObject.Age = 30;

    Console.WriteLine($"Name: {dynamicObject.Name}, Age: {dynamicObject.Age}");

    // Adding a method dynamically
    dynamicObject.Greet = new Action(() => Console.WriteLine($"Hello, my name is {dynamicObject.Name}"));

    // Invoking the dynamic method
    dynamicObject.Greet();

    // Accessing non-existing property will throw exception
    //var country = dynamicObject.Country;
    //Console.WriteLine($"Country: {country ?? "Unknown"}");
}