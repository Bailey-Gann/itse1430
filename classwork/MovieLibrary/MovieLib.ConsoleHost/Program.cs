/*
 * Bailey Gann
 * ITSE 1430
 * Classwork Day 1
 */

using System;

namespace MovieLib.ConsoleHost
{
    class Program
    {
        //Entry point
        static void Main(string[] args)
        {
            var done = false;

            do
            {
                char input = DisplayMenu();

                //Handle input
                switch (input)
                {
                    case 'a': //Fallthrough is allowed when case statement is empty
                    case 'A': AddMovie(); break;

                    case 'v':
                    case 'V': ViewMovie(); break;

                    case 'q':
                    case 'Q':
                    {
                        if (ConfirmQuit())
                            done = true;
                    }; break;

                    case 'd':
                    case 'D': DeleteMovie(); break;

                    case 'e':
                    case 'E': EditMovie(); break;
                    default: Console.WriteLine("Unknown option"); break;
                };
                
            } while (!done);
            
        }

        #region Menu Functions
        //Handle input 'A', for adding a movie
        private static void AddMovie ()
        {
            movie = new Movie();
            do
            {
                movie.Title = ReadString("Enter a movie title: ", true);
                //movie.setTitle(ReadString("Enter a movie title: ", true));
                movie._duration = ReadInt32("Enter duration in minutes (>=0): ", 0);
                //movie.setDuration(ReadInt32("Enter duration in minutes (>=0): ", 0));
                movie._releaseYear = ReadInt32("Enter the release year: ", 1900);
                //movie.setReleaseYear(ReadInt32("Enter the release year: ", 1900));
                movie._rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
                //movie.setRating(ReadString("Enter a rating (e.g. PG, PG-13): ", true));
                movie._genre = ReadString("Enter a genre (optional): ", false);//can be array, as movies fit multiple genres sometimes
                                                                              //movie.setGenre(ReadString("Enter a genre (optional): ", false));
                movie._isClassic = ReadBoolean("Is classic (Y/N)? ");
                //movie.setIsColor(ReadBoolean("In color (Y/N)? "));
                movie._description = ReadString("Enter a description (optional): ", false);
                //movie.setDescription(ReadString("Enter a description (optional): ", false));

                //movie.isBlackAndWhite = movie.releaseYear <= 1939;
                movie.CalculateBlackAndWhite();

                var error = movie.Validate();
                if (String.IsNullOrEmpty(error))
                    return;

                Console.WriteLine(error);
            } while (true);
        }
        //Handle input 'E', giving the user a message "Feature not yet supported"
        private static void EditMovie ()
        {
            Console.WriteLine("Feature not yet supported...");
            
        }
        //Handle input 'D', for deletion of movie
        private static void DeleteMovie ()
        {
            //if (String.IsNullOrEmpty(movie.title))
            if(movie == null)
            {
                Console.WriteLine("No movie to delete.");
                return;
            }

            //Delete the movie
            if(ReadBoolean($"Are you sure you want to delete '{movie._title}' (Y/N) "))
                movie = null;
        }
        //Handle input 'V', for viewing movie
        private static void ViewMovie ()
        {
            //Does movie exist
            //if (String.IsNullOrEmpty(movie.title))
            if(movie == null)
            {
                Console.WriteLine("No movie to view");
                return;
            };

            
            Console.WriteLine(movie._title);

            //releaseYear (duration mins) rating
            //Formatting 1 - string concatenation
            //Console.WriteLine(releaseYear + " (" + duration + " mins) " + rating);

            //Formatting 2 - string formatting
            //Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //string temp = String.Format("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //Console.WriteLine(temp);

            //Formatting 3 - string interpolation
            //ONLY WORKS ON STRING LITERALS, NOT ON STORED VALUES
            Console.WriteLine($"{movie._releaseYear} ({movie._duration} mins) {movie._rating}");

            //genre (Color | Black White)
            //Console.WriteLine(genre + " (" + isColor + ")");
            //if(isColor)
            //    Console.WriteLine($"{genre} (Color)");
            //else
            //    Console.WriteLine($"{genre} (Black and White)");
            //Conditional operator
            //'Bool value'/' ? '/ 'true value'/ ' : '/ 'false value'
            Console.WriteLine($"{movie._genre} ({(movie._isClassic ? "Classic" : "")})");

            //Console.WriteLine(duration);
            //Console.WriteLine(isColor);
            //Console.WriteLine(rating);
            //Console.WriteLine(genre);
            Console.WriteLine(movie._description);
        }
        //Handle input 'Q', for quitting the program
        static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit (Y/N)? ");
            
        }
        
        #endregion

       
        static Movie movie;
              

        #region Helper Functions
        static bool ReadBoolean (string message )
        {
            //TODO: Fix prompt
            Console.Write(message);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                //TODO: Validate

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

        private static int ReadInt32 ( string message, int minValue )
        {
            Console.Write(message);

            while (true)
            {
                //Type inferencing - compiler infers actual type based upon usage
                //Has 0 impact on runtime behavior
                //string input = Console.ReadLine();
                var input = Console.ReadLine();

                //Validate
                //int result = Int32.Parse(input);

                //int result;
                //if (Int32.TryParse(input, out result))

                //if (Int32.TryParse(input, out int result))
                //    if (result >= minValue)
                if (Int32.TryParse(input, out int result) && result >= minValue)
                        return result;

                Console.WriteLine("Value must be  >= " + minValue);

            };

        }

        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);

            do
            {
                string input = Console.ReadLine();

                //Validate input, if required
                if (!required || !String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Value is required");
            } while (true);
        }
       

        static char DisplayMenu ()
        {
            Console.WriteLine("\nMovie Library");
            //Console.WriteLine("-------------");
            Console.WriteLine("".PadLeft(20, '-'));
            Console.WriteLine("\nA)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");

            do
            {
                string input = Console.ReadLine()/*.ToUpper()*/;
                Console.WriteLine(" ");

                //Validate input
                if (String.Compare(input, "A", true) == 0)
                {
                    return 'A';
                } else if (String.Compare(input, "V", true) == 0)
                {
                    return 'V';
                } else if (String.Equals(input, "E", StringComparison.CurrentCultureIgnoreCase))
                {
                    return 'E';
                } else if (String.Compare(input, "D", true) == 0)
                {
                    return 'D';
                } else if (String.Compare(input, "Q", true) == 0)
                {
                    return 'Q';
                } else
                {
                    Console.WriteLine("Invalid input");
                };
            } while (true);
            
        }
        #endregion
    }
}
