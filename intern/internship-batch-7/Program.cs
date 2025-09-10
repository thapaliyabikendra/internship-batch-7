using System;

namespace internship_batch_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World !");
            Console.WriteLine("Welcome to c# Programming !");
            Console.WriteLine("My name is Nirajan");

            Console.WriteLine();

            // 100 words reflection on me
            Console.WriteLine("Refection on me");
            Console.WriteLine("-----------------");
            Console.WriteLine("Programming to me, is both a creative and logical process that allows me to solve real-world problems by transforming ideas into functional solutions. Through programming, I can continuously grow and challenge myself, which is a key motivator. For this internship, my goal is to deepen my understanding of C# and strengthen my coding skills. I also hope to learn about microservices, .NET, Angular, and stored procedures. Gaining expertise in these technologies will expand my ability to design scalable, efficient applications and give me a comprehensive understanding of modern software development practices. This opportunity is a stepping stone towards becoming a well-rounded developer.");

            Console.WriteLine();

            //Bonus challenge
            Console.WriteLine("Bonus Challenge");
            Console.WriteLine("-----------------");
            Console.Write("Enter your User name : ");
            string username = Console.ReadLine();
            Console.WriteLine("Your's Username is " + username);

            string date = DateTime.Now.ToString("yyyy-MM-dd"); 
            Console.WriteLine("Today Date is : " + date);

            //Console.ReadKey();
        }
    }
}
