// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Runtime.InteropServices;
unsafe
{
    int i1 = 23;
    int i2 = 9;
    int* a=&(i1);
    int* b=&(i2);

    Console.WriteLine($"{i1} - {i2}");
    Processor.MySwap(a, b);
    Console.WriteLine($"{i1} - {i2}");
    Console.ReadLine();
}





