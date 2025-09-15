namespace Project.conversion;

internal class Program
{
    static void Main(string[] args)
    {
        /* - Write a program where:
           - You assign an `int` to a `double`.
           - You assign a `char` to an `int` and print its Unicode value.
        */


        int a = 23;
        double b = a;//this is implicit conversion  no data lost


        char ch = 'S';
        int unicode = ch;
        Console.Write("unicode value "+unicode);

        /*  - Write a program where:
            - You convert a `double` to an `int` using explicit casting.
            - Try converting a `float` to a `byte`. Print the results and note what happens.*/



        double pi = 3.14;
        int int_Pi = (int)pi;

        Console.WriteLine("convert double to int :" + int_Pi);

        float fl = 222.435556f;
        byte floatToByte = (byte)fl;

        Console.WriteLine("after the conversion to byte: "+floatToByte);//this is ecplesit conversion where data loss occurs


        /*  Take a string `"100"` and convert it into:
            - `int`
            - `double`
            - `bool` (try `"true"` instead of `"100"` for testing)
            - Print the results.*/



        string s = "100";

        int num = Convert.ToInt32(s);

        double decimalNum = Convert.ToDouble(s);

        try
        {
            bool bo = Convert.ToBoolean(s); // will fail for "100"
            Console.WriteLine("String to bool: " + bo);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Cannot convert 100 to bool: " + ex.Message);
        }

        /*Parsing Strings**
            - Parse the string `"250"` into an `int`.
            - Try parsing `"25A"` and observe what happens.  
            _(Hint: Use try-catch block to handle exceptions.)_
        */


        string s2 = "250";
        int num2 = int.Parse(s2);

        string s3 = "25A";
        try
        {
            int num3 = int.Parse(s3);
        }
        catch
        {
            Console.WriteLine("invalid data for int");
        }

        /*5. TryParse (Safe Parsing)**
                - Use `int.TryParse()` for the input `"999"`.
                - Use `int.TryParse()` for the input `"99X"`.
                - Print whether parsing succeeded or failed in both cases.*/

        string s4 = "999";
        int num4;
        

        bool result = int.TryParse(s4, out num4);

        if (result)
        {
            Console.WriteLine($"Conversion successful: {num4}");
        }
        else
        {
            Console.WriteLine("Conversion failed.");
        }


        string s5 = "99X";
        int num5;


        bool result1 = int.TryParse(s5, out num5);

        if (result)
        {
            Console.WriteLine($"Conversion successful: {num5}");
        }
        else
        {
            Console.WriteLine("Conversion failed as X is present.");
        }



        //obj casting

        object obj = "hello";

        // 2. Using 'as' to cast it back to string
        string str1 = obj as string; // returns null if casting fails

        if (str1 != null)
        {
            Console.WriteLine($"output after using 'as': {str1}");
        }

        // 3. Using 'is' to check before casting

        if (obj is string) // returns true if obj is a string
        {
            
            Console.WriteLine("output after using 'is'");
        }



        //boxing and on boxing

        int num6 = 45;
        object obj1 = num6;
        ConversionProgram();
    }

    public static void ConversionProgram()
    {
        

        Console.WriteLine("\nEnter the number or String you want to convert");
        var answer= Console.ReadLine();
        int parsedNumber;
        bool isInteger = int.TryParse(answer, out parsedNumber);


        try
        {
            if (isInteger)//when th einput is int we are converting to other format
            {
                Console.WriteLine("======================Choose From Options======================");
                Console.WriteLine("1.Use explisit conversion");
                Console.WriteLine("2.Use implisit conversion");
                Console.WriteLine("3.Use Conversion method");
                Console.WriteLine("4.Use Parse conversion");
                Console.WriteLine("5.Use TryParse conversion");
                Console.WriteLine("6.boxing the input and then unboxing");
                Console.WriteLine("7.Use as/is");
                Console.WriteLine("=================================================================");
                Console.WriteLine("Enter the options ");
                int choice = int.Parse(Console.ReadLine());




                switch (choice)
                {

                    case (1):
                        Console.WriteLine("\nConverting the int to double explicitly");
                        double num7 = (double)parsedNumber;
                        Console.WriteLine("Converted to double using explesit " + num7);

                        break;

                    case (2):
                        Console.WriteLine("\nConverting the int to double implesit");
                        double num8 = parsedNumber;
                        Console.WriteLine("Converted to double using implesit " + num8);
                        break;

                    case (3):
                        Console.WriteLine("\nConverting the string to double conversion method");
                        double num9 = Convert.ToDouble(answer);
                        Console.WriteLine("Converted to double using conversion method " + num9);
                        break;

                    case (4):
                        Console.WriteLine("\nConverting the string to double inplesit");
                        double num10 = double.Parse(answer);
                        Console.WriteLine("Converted to double using implesit " + num10);
                        break;

                    case (5):
                        Console.WriteLine("\nChecking if the given input is int");
                        bool checkValue = int.TryParse(answer, out int numbers);
                        Console.WriteLine("The output is: " + checkValue);
                        break;

                    case (6):
                        Console.WriteLine("\nBoxing the input");
                        object boxInput = answer;
                        Console.WriteLine("The boxed value is: " + boxInput);
                        Console.WriteLine("\nUnBoxing the boxed value into int");
                        int unBoxInput = (int)boxInput;
                        Console.WriteLine("\nthe unboxed UnBoxing value is " + unBoxInput + " it was converted into int from string");
                        break;

                    case (7):
                        object obj = answer;

                        // 2. Using 'as' to cast it back to string
                        string str1 = obj as string; // returns null if casting fails

                        if (str1 != null)
                        {
                            Console.WriteLine($"output after using 'as': {str1}");
                        }

                        // 3. Using 'is' to check before casting

                        if (obj is string) // returns true if obj is a string
                        {

                            Console.WriteLine("output after using 'is'");
                            int casteToInt = Convert.ToInt32(obj);
                            Console.WriteLine("Casting to int also completed");
                        }

                        break;

                    default:
                        Console.WriteLine("Choose correct option");
                        break;
                }

            }
            else
            {
                Console.WriteLine("the given input is string so conversion to number can be done!!!!!!!!!!!!!!!!!!!");
            }
        }
        catch
        {
            Console.WriteLine("the input must be int");
        }
            

    }
}





