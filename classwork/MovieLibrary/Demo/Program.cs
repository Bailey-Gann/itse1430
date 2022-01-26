/*
 * Bailey Gann, Captain
 * C# Basics
 */

using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primitives
            //Integrals
            sbyte sbyteValue = 10;
            short shortValue = 20;
            int intValue = 65_432_198;
            long longValue = 40L; //'L' is not mandatory. Makes it a long literal opposed to the default int literal

            //Floats
            float floatValue = 654.113F; //Leave out the 'F' or 'f', recieve an error
            double doubleValue = 5642.444;
            decimal payRate = 17.99M; //Leave out the 'm' or 'm', recieve an error

            //Boolean
            bool answer = false;
            bool otherAnswer = true;

            //Char
            char letterGrade = 'A';

            //String
            string name = "Captain Bailey Gann";


            //Other types, Non-Primitive
            DateTime x; //Date and a time. Same as SQL
            TimeSpan xy; //Duration, accurate to miliseconds
            Guid xyz; //Everything is a Guid (Globally Unqiue Identifier) - a string of byte values, 64 bytes (statistically speaking, they are unique)

            

        }
    }
}
