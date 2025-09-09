using System;
namespace Suyasha.helloworld;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your name ");
        var name=Console.ReadLine();
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Welcome to C# programming");

        Console.WriteLine($"My name is {name}");

        Console.WriteLine("Todays date is "+ DateTime.Today.ToString("D"));
    }
}
