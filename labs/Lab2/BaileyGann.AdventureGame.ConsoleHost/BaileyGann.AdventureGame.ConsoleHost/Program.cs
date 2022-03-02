/*
* Bailey Gann
* ITSE 1430
* Lab 2
*/

using System;

namespace BaileyGann.AdventureGame.ConsoleHost
{
    class Program
    {
        static string[] blank;
        static void Main(string[] args)
        {
            int mainCalled = 0;
            if(mainCalled == 0)
            {
                var today = DateTime.Now;
                Console.WriteLine("Bailey Gann \nITSE 1430 \n" + today + "\n");
            }

            mainCalled++;

            do
            {

            } while (true);
        }

        static char DisplayMenu ()
        {
            Console.WriteLine("\n");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Q)uit\n");

            string input = Console.ReadLine().ToUpper();

            //Validate input
            //else
            //{
            //    Console.WriteLine("Invalid input");
            //    Console.WriteLine(" ");
            //    return 'X';
        };
            private static void CallToQuit ()
        {
            bool answer = Confirm("Are you sure you want to quit? (Y/N)");

            if (answer == false)
                Main(blank);
            else
            {
                Console.WriteLine("\nGoodbye!!\n");
                //Terminate Program
            }
        }
        static string GetStringInputList (string[] arrayUsed, string message )
        {
            string input = "";
            bool validateOption = false;

            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToUpper();

                for (int i = 0; i < arrayUsed.Length; i++)
                {
                    if(input == arrayUsed[i].ToUpper())
                    {
                        input = input.ToUpper();
                        validateOption = true;
                        break;
                    } 
                }
                if(validateOption == false)
                {
                    Console.WriteLine("Invaild input! \nPlease choose a value from the list...\n");
                } 

            } while (!validateOption);

            return input;
        }

        static string GetStringInput_NON_List ( string message )
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }
        static bool Confirm ( string message )
        {
            Console.Write(message);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                //Validate 'Y' or 'N'

                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine('Y');
                    return true;

                } else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine('N');
                    return false;
                };
            } while (true);
        }
    }
}
//Story 0:
//Story 1: Complete
//Story 2: Complete
//Story 3:
//Story 4:
//Story 5:
//Story 6:
//Story 7:
//Story 8: