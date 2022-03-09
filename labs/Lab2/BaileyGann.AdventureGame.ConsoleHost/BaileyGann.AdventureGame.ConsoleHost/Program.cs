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
       static Player s_kirby = new AdventureGame.Player();
       static World s_gameWorld = new AdventureGame.World();
        static void Main ( string[] args )
        {




            Console.WriteLine($"Bailey Gann \nITSE 1430 \n{DateTime.Now}\n\n");
                
            Console.WriteLine(s_gameWorld.WorldDescription);

            GameLoop();

        }

        #region Game Loop Methods
        static void GameLoop ()
        {
            char inputChar = 'X';
            do
            {
                inputChar = DisplayMenu();
            } while (inputChar == 'X');


            if (inputChar == 'Q')
            {
                CallToQuit();
            }
            else if(inputChar == 'M')
            {
                Move(s_kirby);
            } else if (inputChar == 'L')
            {
                Look(s_kirby);
            }else if(inputChar == 'C')
            {
                CurrentState(s_kirby);
            }
            else
            {
                Console.WriteLine("Oops");
            }
                     
            
        }

        static char DisplayMenu ()
        {
            Console.WriteLine("\n");
            Console.WriteLine("C)urrent area/room");
            Console.WriteLine("L)ook");
            Console.WriteLine("M)ove");
            Console.WriteLine("Q)uit\n");

            string input = Console.ReadLine().ToUpper();

            //Validate input
            if (input == "Q")
            {
                return 'Q';
            } else if (input == "M")
            {
                return 'M';
            } else if (input == "L")
            {
                return 'L';
            } else if (input == "C")
            {
                return 'C';
            } else
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine(" ");
                return 'X';
            };
        }
        #endregion

        #region Command Fundtions
        private static bool CallToQuit ()
        {
            return Confirm("Are you sure you want to quit (y/n)? ");
        }

        static void Move (Player name)
        {
            int newRoom = GetIntInputList(name.getRoomChoices(), "Which area/room number do you choose: ");
            name.MoveTo(newRoom);

            Console.WriteLine($"\n{s_gameWorld.getDescription(newRoom)}");

            GameLoop();
        }
        static void Look ( Player name )
        {
            //A function to get a neighboring rooms name while maintaining current room position...

            int newRoom = GetIntInputList(name.getRoomChoices(), "Which area/room number do you choose: ");
            

            Console.WriteLine($"\nThat leads to {s_gameWorld.getName(newRoom)}\n");

            GameLoop();
        }

        static void CurrentState(Player name )
        {
            Console.WriteLine($"You are in the {s_gameWorld.getName(name.RoomNum)}");

            GameLoop();
        }

        #endregion



        #region Helper Functions
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

        static int GetIntInputList ( int[] arrayUsed, string message )
        {
            int result;
            bool validateOption = false;

            do
            {
                Console.Write(message);
                
                for(int i = 0; i < arrayUsed.Length; i++)
                {
                    Console.Write(arrayUsed[i] + " ");
                }
                Console.WriteLine("");

                var input = Console.ReadLine();

                result = Int32.Parse(input);

                for (int i = 0; i < arrayUsed.Length; i++)
                {
                    if (result == arrayUsed[i])
                    {
                        
                        validateOption = true;
                        break;
                    }
                }

                if (validateOption == false)
                {
                    Console.WriteLine("Invaild input! \nPlease choose a value from the list...\n");
                }
            

            } while (!validateOption);

            return result;
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

        #endregion
    }
}
//Story 0: Complete (look in class World)
//Story 1: Complete
//Story 2: Complete
//Story 3: Complete
//Story 4: Complete
//Story 5: Complete
//Story 6: Complete
//Story 7: Complete
//Story 8: Complete
