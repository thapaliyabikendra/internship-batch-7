using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nImplicite Type casting");
            int number = 10;
            double decimalNumber = number; //Implicit Type casting
            Console.WriteLine($"Integer {number} to Decimal value:{decimalNumber:F2}");
            char unicode = 'a';
            int characterUnicode = unicode; //imlicit Type casting
            Console.WriteLine($"Character {unicode} to Interger value;{characterUnicode}");


            Console.WriteLine("\nExplicite Type casting");
            double convertToInt = 3.14;
            int convertedToInt = (int)convertToInt; //Explicit Conversion
            Console.WriteLine($"Double {convertToInt} to Interger:{convertedToInt}");
            float convertToByte = 3.4f;
            byte convertedToByte = (byte)convertToByte; //Explicit
            Console.WriteLine($"Float {convertToByte} to Byte:{convertedToByte}");


            Console.WriteLine("\nType casting using convert");
            string numberValue = "100";
            int stringToInt = Convert.ToInt32(numberValue); //convert class
            double stringToDouble = Convert.ToDouble(numberValue);
            string toBool = "true";
            bool fromString = Convert.ToBoolean(toBool);//convert class
            Console.WriteLine($"String {numberValue} to Integer; {stringToInt} and Double:{stringToDouble:F2} and Bool {fromString}");



            Console.WriteLine("\nType casting using parsing");
            string parsingString = "250";
            int toInterger = int.Parse(parsingString);
            Console.WriteLine($"String {parsingString} to Integer {toInterger}");
            string characterparsing = "25A";
            try
            {
                int fromcharacterpars = int.Parse(characterparsing);//throws exception due to formatexception
            }
            catch (System.FormatException) //catch system.formatException
            {
                Console.WriteLine($"{characterparsing} is not valid for parsing");
            }


            Console.WriteLine("\nType casting and safe parsing");
            bool success1 = int.TryParse("999", out int result1);
            Console.WriteLine($"TryParse '999': Success={success1}, Result={result1}");//safe parsing using tryparse
            bool success2 = int.TryParse("99X", out int result2);
            Console.WriteLine($"TryParse '99X': Success={success2}, Result={result2}");
            //int parsing999 = int.Parse("999");
            //Console.WriteLine($"Parsing for 999");
            //try
            //{
            //    int parsing99x = int.Parse("99X");
            //}
            //catch (System.FormatException)
            //{
            //    Console.WriteLine($"Parsing for 99X not avilable");
            //}


            Console.WriteLine("\nObject Conversion");
            object obj = "hello";
            string ?strAs = obj as string; //use of as to convert to string
            Console.WriteLine($"Using 'as': {strAs}");
            bool isString = obj is string; //use of is to determine data type
            Console.WriteLine($"obj is a string{isString}");


            Console.WriteLine("\nBoxing and Unboxing");
            int original = 123;
            object boxed = original;//Boxing
            int unboxed = (int)boxed;//Unboxing
            Console.WriteLine($"Boxed value: {boxed}, Unboxed value: {unboxed}\n\n");
            RunMenue();

        }
        static void RunMenue()
        {
            string? input;
            int number;

            Console.WriteLine("Enter a integer value:");

            while (!int.TryParse(input = Console.ReadLine(), out number))//input form user untill an input
            {
                Console.WriteLine("Invalid input. Enter a valid double:");
            }

            bool exit=false;
            while (!exit)//loop untill exit personally
            {
            Console.WriteLine($"Enter Type of Conversion You want");
            Console.WriteLine("1 : For Implicit\n2 :For Explicit\n3 :For Convert \n4 :For Parse \n5 :For TryParse \n6 :For is&as\n7 :For Boxing and Unboxing\n8 :For Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        double implicitCasting = number;//implicit
                        Console.WriteLine($"Implicit casting\nInteger {number} to Double {implicitCasting:F2}");
                        break;
                    case "2":
                        double explicitCasing = (double)number;//explicit
                        Console.WriteLine($"Explicit casting\nInteger {number} to Double {explicitCasing:F2}");

                        break;

                    case "3":
                        double convertCasting = Convert.ToDouble(number);//convertclass
                        Console.WriteLine($"Convert class casting\nInteger {number} to Double {convertCasting:F2}");

                        break;
                    case "4":
                        double parsingCasting = double.Parse(input);//parsing
                        Console.WriteLine($"Paring casting\nInteger {number} to Double {parsingCasting:F2}");

                        break;
                    case "5":
                        bool success = int.TryParse(input, out int result);//tryparsing
                        Console.WriteLine(success ? $"TryParse success: {result}" : "TryParse failed.");
                        break;

                    case "6":
                        object obj = input;//object to string
                        if (obj is string)
                            Console.WriteLine($"'is' check passed: {(string)obj}");
                        else
                            Console.WriteLine("'is' check failed.");

                        break;
                    case "7":
                        int val =Convert.ToInt32(number);//boxing and unboxing
                        object boxed = val;
                        int unboxed = (int)boxed;
                        Console.WriteLine($"Boxed: {boxed}, Unboxed: {unboxed}");
                        break;
                    case "8":
                        exit = true;
                        return;
                }
            }
            
        }
    }
}
