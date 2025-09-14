using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_four
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment four");
            Console.WriteLine("-----------------");

            ImplicitConversion();
            ExplicitConversion();
            ConvertClass();
            PasingStrings();
            TryParseUsing();
            ConvertingBetweenObjects();
            BoxingAndUnboxing();
        }

        #region Q1) Implicit Conversion
        static void ImplicitConversion()
        {
            Console.WriteLine("Q1. Implicit Conversion");
            Console.WriteLine("----------------------");
            int number = 123;
            double result1 = number;
            Console.WriteLine("  1.Implicit Conversion number int to double is :" + result1);

            // char to int. gives unicode value(number value) of that character(A to Z). 
            Console.WriteLine();
            char letter = 'N';
            int resultUnicodeValue = letter;
            Console.WriteLine("  2. Implicit Conversion char to int is :" + resultUnicodeValue);

            Console.WriteLine();
            Console.WriteLine("Answer : ");
            Console.WriteLine("They are safe conversion because of no data loss.");
        }
        #endregion

        #region Q2) Explicit Conversion
        static void ExplicitConversion()
        {
            Console.WriteLine();
            Console.WriteLine("Q2. Explicit Conversion");
            Console.WriteLine("----------------------");
            double dNumber1 = 10.23;
            int roundedNumber = (int)dNumber1;
            Console.WriteLine("  1. Explicit Conversion double to int using cast is :" + roundedNumber);

            Console.WriteLine();
            float fNumber1 = 12.12f;
            byte byteConvert = (byte)fNumber1;
            Console.WriteLine("  2. Explicit Conversion float to byte using cast is :" + byteConvert);

            Console.WriteLine();
            Console.WriteLine("Answer : Explicit Conversion might be data loss. If we convert double(10.23) to int ans 10 will return .23 will be remove. In float(fraction part known as real number or decimal) to byte(known as whole number). if we did not take fraction number it will not loss the data and if we took it will loss the data. ");
        }
        #endregion

        #region Q3) Using convert class
        static void ConvertClass()
        {
            Console.WriteLine();
            Console.WriteLine("Q3. Convert Class");
            Console.WriteLine("_______________");

            //for number string 
            string number = "100";
            //for bool string
            string boolString = "true";
            int convertInt = Convert.ToInt32(number);
            Console.WriteLine("  1. String to int by using convert class is: " + convertInt);

            Console.WriteLine();
            double convertIntoDouble = Convert.ToDouble(number);
            Console.WriteLine("  2. String to double by using convert class is: " + convertIntoDouble);

            Console.WriteLine();
            bool convertIntoBoolen = Convert.ToBoolean(boolString);
            Console.WriteLine("  3. String to Bool by using convert class is: " + convertIntoBoolen);

        }
        #endregion

        #region Q4) parsing strings
        static void PasingStrings()
        {
            Console.WriteLine();
            Console.WriteLine("Q4. Pasing String");
            Console.WriteLine("_______________");

            //parse the string "250" into integer
            string parseInt1 = "250";
            try
            {
                int result1 = int.Parse(parseInt1);
                Console.WriteLine("  1. The result of parsing string 250 into int. Answer =" + result1);
            }
            catch (Exception)
            {

                throw;
            }
             
            // try parse the string "250A" into integer
            string parseInt2 = "250A";
            try
            {
                int result2 = int.Parse(parseInt2);
                Console.WriteLine("  2. The result of parsing string 250A into int. Answer =" + result2);
            }
            catch (Exception)
            {
                Console.WriteLine("  2. Input string was not in a correct format.");
            }

            Console.WriteLine();
            Console.WriteLine("Ans => if we take string 250 the 250 is integer so, it return 250 and if we take 250A is string, it throw System.FormatException: 'Input string was not in a correct format.' exception.");
        }
        #endregion

        #region Q5) TryParse(safe parsing)
        static void TryParseUsing()
        {
            Console.WriteLine();
            Console.WriteLine("Q5. TryParse (Safe Parsing)");
            Console.WriteLine("-------------------------");

            //use int.TryParse for input "999"
            string inputOne = "999";
            bool checking = int.TryParse(inputOne,out int resultValue1);

            if (checking == true)
            {
                Console.WriteLine("  1. The answer of input string 999 => " + resultValue1);
            }
            else
            {
                Console.WriteLine("  1. Failed to pass string 999 !");
            }

            //use int.TryParse for input "99x"
            Console.WriteLine();
            string inputTwo = "99x";
            bool checking2 = int.TryParse(inputTwo,out int resultValue2);

            if (checking2 == true)
            {
                Console.WriteLine("  2. The answer of input string 99x => " + resultValue2);
            }
            else
            {
                Console.WriteLine("  2. Failed to pass string 99x !");
            }
        }
        #endregion

        #region Q6) converting between objects(as /is)
        static void ConvertingBetweenObjects()
        {
            Console.WriteLine();
            Console.WriteLine("Q6. converting between objects(as /is)");
            Console.WriteLine("-----------------------------------------");

            object obj = "hello";

            //as keyword to cast it back to string
            //as => (Return null)
            string s = obj as string;
            Console.WriteLine("  1. The answer as keyword to cast it back to string : " + s);

            //is keyword to check if the object is string before casting
            //is => (Return as boolen)
            if (obj is string)
            {
                Console.WriteLine("  2. The answer is keyword to check if the object is string before casting : " + obj);
            }
            else
            {
                Console.WriteLine("  2. cast failed !");
            }

        }
        #endregion

        #region Q7) Boxing and unboxing
        static void BoxingAndUnboxing()
        {
            Console.WriteLine();
            Console.WriteLine("Q7. Boxing and Unboxing");
            Console.WriteLine("-----------------------------");

            int realValue = 10;

            //boxing an integer value into object
            object boxedValue = realValue;
            Console.WriteLine("Boxing int value type into object : " + boxedValue);

            //unboxing it back to an integer .
            int unBoxedValue = (int)boxedValue;
            Console.WriteLine("Unboxing object back into an orginal value type integer : " + unBoxedValue);

            Console.WriteLine();
            Console.WriteLine("Ans : boxing : value type into object. Unboxing: object back into acutal value type. Unboxing, If the object doesn’t actually contain the correct value type, it throws an InvalidCastException.");
        }
        #endregion

    }
}
