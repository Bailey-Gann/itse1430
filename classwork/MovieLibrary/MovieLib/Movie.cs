using System;

namespace MovieLib
{
    //Class - wraps data and functionality
    //   Naming: nouns, PascalCased
    public class Movie
    {
        //Fields - where the data is stored
        //Naming: nouns, camelCased
        //    Readable and writable ( assuming accesibility)
        //    Work just like all other variables
        //
       public string title;
       public int duration;
       public int releaseYear = 1900;
       public string rating;
       public string genre;
       public bool isColor;
       public string description;

        private int id;

        public Movie (int id)
        {
            this.id = id;
        }

        #region Getters
        public string getTitle ()
        {
            return this.title;
        }
        public int getDuration ()
        {
            return this.duration;
        }
        public int getReleaseYear ()
        {
            return this.releaseYear;
        }
        public string getRating ()
        {
            return this.rating;
        }
        public string getGenre ()
        {
            return this.genre;
        }
        public bool getIsColor ()
        {
            return this.isColor;
        }
        public string getDescription ()
        {
            return this.description;
        }
        public int getID ()
        {
            return this.id;
        }
        #endregion
        #region Setters
        public void setTitle(string title )
        {
            this.title = title;
        }
        public void setDuration(int duration )
        {
            this.duration = duration;
        }
        public void setReleaseYear(int year )
        {
            this.releaseYear = year;
        }
        public void setRating(string rating )
        {
            this.rating = rating;
        }
        public void setGenre(string genre )
        {
            this.genre = genre;
        }
        public void setIsColor(bool isColor )
        {
            this.isColor = isColor;
        }
        public void setDescription(string description )
        {
            this.description = description;
        }
        #endregion
    }
}
