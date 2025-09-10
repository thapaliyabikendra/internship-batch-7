
namespace Helloworld
{
    internal class Program
    {
        public static string? Name;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\nWelcome to C# Programming!\nMy name is Subesh Gumanju\n");
            Name = Console.ReadLine();
            Console.WriteLine($"Your Name is {Name}");
            Console.WriteLine($"Todays Date is {DateTime.Now}\n");
        }
    }
}

