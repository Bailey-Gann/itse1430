/*
 * Bailey Gann
 * ITSE 1430
 * Lab 1
 */

using System;

namespace CharacterCreator.ConsoleHost
{
    class Program
    {
        //Data for the character to be made
        static string name = ""; //required
        static string profession = ""; //required
        static string race = ""; //required
        static int[] attributes = { 0, 0, 0, 0, 0 };
        static string description = " "; //not required
        //********************************************
        //Class / Race data

        static string[] races = { "Vampire", "Human", "Pixie", "Elf", "Phantom", "ERROR" };
        static string[] classes = { "Wizard", "Fighter", "Warlock", "Rogue", "Druid", "ERROR" };
        static string[] attributeNames = { "Strength", "Intelligence", "Constitution", "Dexterity", "Charisma / Magic" };
        static string[] editArray = { "Name", "Race", "Profession", attributeNames[0], attributeNames[1], attributeNames[2], attributeNames[3], attributeNames[4], "Description" };
        //***************************************************************************************

        static char input2;

        //Entry Point
        static void Main(string[] args)
        {
            //Get today's date and time
            DateTime today = DateTime.Now;
            Console.WriteLine("Bailey Gann \nITSE 1430 \n" + today + "\n");
          
            //Let the building begin... :)
            MenuLoop();
        }

        private static void MenuLoop ()
        {
            Console.WriteLine(" ");
            do
            {
                input2 = DisplayMenu();
                Console.WriteLine(" ");
            } while (input2 == 'X');

            ValidateMenuInput(input2);
            Console.WriteLine(" ");
        }

        private static void ValidateMenuInput (char input)
        {
            if (input =='C')
            {
                CreateCharacter();
            } else if (input == 'V')
            {
                ViewCharacter();
            } else if (input == 'D')
            {
                DeleteCharacter();
            } else if (input == 'E')
            {
                EditCharacter();
            } else
                CallToQuit();
        }

        private static void DeleteCharacter ()
        {
            if (name == "")
                Console.WriteLine("No character to delete");
            else
            {
                bool answer = Confirm("Are you sure you want to delete " + name + "?");
                if(answer == true)
                {
                    name = "";
                    race = "";
                    profession = "";
                    for(int i = 0; i < 5; i++)
                    {
                        attributes[i] = 0;
                    }
                    description = "";
                }
            }

            //Last line of function...
            MenuLoop();
        }
        private static void EditCharacter ()
        {
            bool answer;

            
          if(name != "")
            {
                for (int i = 0; i < 9; i++)
                {
                    answer = Confirm("Would you like to edit your character's : " + editArray[i]);
                    if (answer == true)
                    {
                        if (i == 0)
                        {
                            name = GetStringInput_NON_List("Enter a new name: ");
                        } else if (i ==1)
                        {
                            race = GetStringInputList(races, "Input a new race option from the list: ");
                        } else if (i == 2)
                        {
                            profession = GetStringInputList(classes, "Input a new profession from the list : ");
                        } else if (i == 3)
                        {
                            Console.WriteLine("Input value 0 - 100 : ");
                            attributes[0] = GetNumberValue();
                        } else if (i == 4)
                        {
                            Console.WriteLine("Input value 0 - 100 : ");
                            attributes[1] = GetNumberValue();
                        } else if (i == 5)
                        {
                            Console.WriteLine("Input value 0 - 100 : ");
                            attributes[2] = GetNumberValue();
                        } else if (i == 6)
                        {
                            Console.WriteLine("Input value 0 - 100 : ");
                            attributes[3] = GetNumberValue();
                        } else if (i == 7)
                        {
                            Console.WriteLine("Input value 0 - 100 : ");
                            attributes[4] = GetNumberValue();
                        } else if (i == 8)
                        {
                            description = GetStringInput_NON_List("Enter a new description (NOTE: This new input will REPLACE any existing data.");
                        } else
                        {
                            break;
                        }

                    }//end of if statement
                    else
                    {
                        Console.WriteLine("Ok. Moving on...");
                        //Proceed with the loop
                    }//end of else statement
                }//end of for loop
            } else
            {
                Console.WriteLine("No character to edit.\nMoving on...");
            }

            //Last line...
            MenuLoop();
        }
        private static void ViewCharacter ()
        {
            if (name == "")
                Console.WriteLine("No character to display");
            else
            {
                Console.WriteLine("NAME: " + name);
                Console.WriteLine("RACE: " + race);
                Console.WriteLine("PROFESSION: " + profession);
                Console.WriteLine("ATTRIBUTES: ");
                for (int i = 0; i< 5; i++)
                {
                    Console.WriteLine("\t ->" + attributeNames[i].ToUpper() + ": " + attributes[i]);
                }
                Console.WriteLine("\nDESCRIPTION: " + description);
            }

            MenuLoop();
        }
        private static void CreateCharacter ()
        {
            //Races: Vampire, Human, Pixie, Elf, Phantom
            //Classes/Professions : Wizard, Fighter, Warlock, Rogue, Druid
            string message1 = "Choose your Profession: Fighter, Druid, Rogue, Warlock or Wizard";
            string message2 = "Choose your Race: Human, Pixie, Elf, Phantom or Vampire";
            string message3 = "Please input a name for the Character: ";
            string message4 = "Please enter a description of the Character ( or hit ENTER to leave blank)";

            name = GetStringInput_NON_List(message3);
            race = GetStringInputList(races, message2);
            profession = GetStringInputList(classes, message1);

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter values for the Attribute: " + attributeNames[i].ToUpper());
                attributes[i] = GetNumberValue();
            }

            description = GetStringInput_NON_List(message4);

            //Last line of function...
            MenuLoop();

        }

        private static void CallToQuit ()
        {
           bool answer = Confirm("Are you sure you want to quit? (Y/N)");

            if (answer == false)
                MenuLoop();
            else
            {
                Console.WriteLine("\nGoodbye!!\n");
                //Terminate Program
            }
        }

        static char DisplayMenu ()
        {
            Console.WriteLine("C)reate Character");
            Console.WriteLine("V)iew Character");
            Console.WriteLine("E)dit Character");
            Console.WriteLine("D)elete Character");
            Console.WriteLine("Q)uit");

            string input = Console.ReadLine().ToUpper();

            //Validate input
            if (input == "C")
            {
                Console.WriteLine(" ");
                return 'C';
            } else if (input == "V")
            {
                Console.WriteLine(" ");
                return 'V';
            } else if (input == "E")
            {
                Console.WriteLine(" ");
                return 'E';
            } else if (input == "D")
            {
                Console.WriteLine(" ");
                return 'D';
            } else if (input == "Q")
            {
                Console.WriteLine(" ");
                return 'Q';
            } else
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine(" ");
                return 'X';
            };

            
        }

        static int GetNumberValue ()
        {
            while (true)
            {
                string input = Console.ReadLine();

                //Validate
               int result;
                if (Int32.TryParse(input, out result))
                    if (result >= 1 && result <= 100)
                        return result;

                Console.WriteLine("Value must be greater than 0 and less than 101 \n");

            };
            
        }

        static string GetStringInputList(string[] arrayUsed, string message)
        {
            string input = "";
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToUpper();

                if (input == arrayUsed[0].ToUpper())
                    return arrayUsed[0].ToUpper();
                else if (input == arrayUsed[1].ToUpper())
                    return arrayUsed[1];
                else if (input == arrayUsed[2].ToUpper())
                    return arrayUsed[2].ToUpper();
                else if (input == arrayUsed[3].ToUpper())
                    return arrayUsed[3];
                else if (input == arrayUsed[4].ToUpper())
                    return arrayUsed[4];
                else {
                    Console.WriteLine("Invaild input! \nPlease choose a value from the list...\n");
                }
                    //Error!!!
                    


            } while (true);



            return null;
        }

        static string GetStringInput_NON_List(string message )
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        static bool Confirm(string message )
        {
            Console.WriteLine(message);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();

                //TODO: Validate

                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine(' ');
                    return true;

                } else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine(' ');
                    return false;
                };
            } while (true);
        }
    }
}

//Story 1: Complete
//Story 2: Complete
//Story 3: Complete
//Story 4: Complete
//Story 5: Complete
//Story 6: Complete
//Story 7: Complete
//Story 8: Complete
