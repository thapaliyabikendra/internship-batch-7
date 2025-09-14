using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu_driven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("menu-driven console program");
                Console.WriteLine("------------------------------");

                
                Console.Write("Enter a number/string : ");
                string input= Console.ReadLine();

                //select the options
                Console.WriteLine();
                Console.WriteLine(" \nSelect a conversion method:");
                Console.WriteLine("1. Implicit");
                Console.WriteLine("2. Explicit");
                Console.WriteLine("3. Convert Class");
                Console.WriteLine("4. Parse");
                Console.WriteLine("5. TryParse");
                Console.WriteLine("6. as/is Operators");
                Console.WriteLine("7. Boxing/Unboxing");
                Console.WriteLine("8. Exit");

                //choose the above options 
                Console.Write("\nChoose a conversion method: ");
                string choice =Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ImplicitConversion();
                     break;

                    case "2":
                        ExplicitConversion();
                        break;

                    case "3":
                        //pass input variable value to ConvertClass method
                        ConvertClass(input);
                        break;

                    case "4":
                        Pasing(input);
                        break;

                    case "5":
                        TryParse(input);
                        break;

                    case "6":
                        ConvertingBetweenObjects(input);
                        break;

                    case "7":
                        BoxingAndUnboxing();
                        break;

                    case "8":
                        Console.WriteLine("Exit");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        #region Implicit Conversion
        static void ImplicitConversion()
        {
            Console.WriteLine("Implicit Conversion");
            Console.WriteLine("----------------------");
            int number = 123;
            double result1 = number;
            Console.WriteLine("  Implicit Conversion number int to double is :" + result1);

            // char to int. gives unicode value(number value) of that character(A to Z). 
            Console.WriteLine();
            char letter = 'N';
            int resultUnicodeValue = letter;
            Console.WriteLine("  Implicit Conversion char to int is :" + resultUnicodeValue);

            Console.WriteLine();
        }
        #endregion

        #region Explicit Conversion
        static void ExplicitConversion()
        {
            Console.WriteLine();
            Console.WriteLine("Explicit Conversion");
            Console.WriteLine("----------------------");
            double dNumber1 = 10.23;
            int roundedNumber = (int)dNumber1;
            Console.WriteLine("  Explicit Conversion double to int using cast is :" + roundedNumber);

            Console.WriteLine();
        }
        #endregion

        #region Using convert class
        static void ConvertClass(string input)
        {
            Console.WriteLine();
            Console.WriteLine("Convert Class");
            Console.WriteLine("_______________");

            try
            {
                int convertInt = Convert.ToInt32(input);
                Console.WriteLine($" String to int by using convert class {input} => {convertInt}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($" Conversion failed : {ex.Message}");
            }


        }
        #endregion

        #region parsing 
        static void Pasing(string input)
        {
            Console.WriteLine();
            Console.WriteLine(" Pasing ");
            Console.WriteLine("_______________");

            try
            {
                int result1 = int.Parse(input);
                Console.WriteLine($" parsing string into int (int.Parse): {input} => {result1}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Parse failed: {ex.Message}");
            }


            Console.WriteLine();
        }
        #endregion

        #region TryParse(safe parsing)
        static void TryParse(string input)
        {
            Console.WriteLine();
            Console.WriteLine(" TryParse (Safe Parsing)");
            Console.WriteLine("-------------------------");

            //use int.TryParse for input 

            bool checking = int.TryParse(input, out int resultValue);

            if (checking == true)
            {
                Console.WriteLine($" The answer of input string {input} =>  {resultValue}");
            }
            else
            {
                Console.WriteLine("  2. Failed to pass string !");
            }
        }
        #endregion

        #region converting between objects(as /is)
        static void ConvertingBetweenObjects(string input)
        {
            Console.WriteLine();
            Console.WriteLine(" converting between objects(as /is)");
            Console.WriteLine("-----------------------------------------");

            object obj = input;

            if (obj is string str)
            {
                Console.WriteLine(" 'is' : obj is a string ");
                string asCast = obj as string;
                Console.WriteLine("'as' : " + asCast);
            }
            else
            {
                Console.WriteLine("  Casting failed. Object is not a string !");
            }

        }
        #endregion

        #region Boxing and unboxing
        static void BoxingAndUnboxing()
        {
            Console.WriteLine();
            Console.WriteLine(" Boxing and Unboxing");
            Console.WriteLine("-----------------------------");

            try
            {
                int realValue = 110;

                //boxing an integer value into object
                object boxedValue = realValue;
                Console.WriteLine("Boxing int value type into object : " + boxedValue);

                //unboxing it back to an integer .
                int unBoxedValue = (int)boxedValue;
                Console.WriteLine("Unboxing object back into an orginal value type integer : " + unBoxedValue);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Unboxing failed: {ex.Message}");
            }

            Console.WriteLine();
        }
        #endregion

    }
}
