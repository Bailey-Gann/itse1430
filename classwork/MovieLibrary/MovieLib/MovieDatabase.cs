using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLib
{
    public class MovieDatabase
    {
        //public MovieDatabase ()
        //{ 
        //    // Do minimal init of instance, if any
        //    // Don't init fields - use field initializers
        //    // Unless
        //    //   Depends on other fields
        //    //   Relies on data available after initialization
        //}

        public MovieDatabase ( string name )
        {
            Name = name;
        }
        //private string _name;

        public string Name { get; set; }

        public void Add ( Movie movie )
        {
        }

        public void Delete ( Movie movie )
        { }

        public Movie Find ( string name )
        {
            return null;
        }

        public Movie Get ()
        {
            return null;
        }

        public void Update ( Movie movie )
        { }
    }
}
