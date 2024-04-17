#define something2

using System.Diagnostics;


#if DEBUG
Console.WriteLine("This is DEBUG!");
#else
Console.WriteLine("This is not DEBUG!");
#endif

#region Some region
#line 8 "custom text"
int i;
#line default
int j;
#line hidden
int k;
#warning "Ahtung!"
int l;
#pragma warning disable
int m;
#pragma warning restore 
int n;
#pragma checksum "Program.cs" "{406EA660-64CF-4C82-B6F0-42D48172A799}" "ab007f1d23d9" 
#endregion
Test();

[Conditional("something2")]
static void Test()
{
    Console.WriteLine("Conditonal Writeline)))");
}

#nullable disable
string? text = null; // здесь nullable-контекст не действует
Console.WriteLine(text.ToStr());
#nullable restore

string? name = null;   // здесь nullable-контекст снова действует
Console.WriteLine(name.ToStr());





Console.ReadKey();


public static class Extension
{
    public static string ToStr(this string? str)
    {
        return str == null ? "NULL" : str;
    }
}