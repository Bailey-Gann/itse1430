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

        /// <summary>
        /// Gets or sets the title of the movie.
        /// </summary>
       
       public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
       private string _title;
       public int _duration;
       public int _releaseYear = 1900;
       public string _rating;
       public string _genre;
       public bool _isClassic;
       public string _description;

        //BW <= 1939
        public bool IsBlackAndWhite
        {
            get { return _isBlackAndWhite; }
            set { }
        }
        public bool _isBlackAndWhite;

        private int id;

        public void CalculateBlackAndWhite ()
        {
            _isBlackAndWhite = _releaseYear <= 1939;
        }

        /// <summary>Validates the instane</summary>
        /// <returns></returns>
        public string Validate ()
        {
            //Title is required
            if (String.IsNullOrEmpty(_title))
                return "\nTitle is required\n";

            if (_duration < 0)
                return "\nDuration must be at least 0\n";

            if (_releaseYear < 1900)
                return "\nRelease year must be at least 1900\n";

            if (String.IsNullOrEmpty(_rating))
                return "\nRating is required\n";

            //Special rule - no classic movies before 1940
            if (_isClassic && _releaseYear < 1940)
                return "\nRelease year must be at least 1940 to be a classic\n";


            return "\n";
        }
        
        public Movie ( /*int id*/ )
        {
            //this.id = id;
        }

        #region Getters
        public string GetTitle ()
        {
            return this._title;
        }
        public int GetDuration ()
        {
            return this._duration;
        }
        public int GetReleaseYear ()
        {
            return this._releaseYear;
        }
        public string GetRating ()
        {
            return this._rating;
        }
        public string GetGenre ()
        {
            return this._genre;
        }
        public bool GetIsColor ()
        {
            return this._isClassic;
        }
        public string GetDescription ()
        {
            return this._description;
        }
        public int GetID ()
        {
            return this.id;
        }
        #endregion
        #region Setters
        public void SetTitle(string title )
        {
            this._title = title;
        }
        public void SetDuration(int duration )
        {
            this._duration = duration;
        }
        public void SetReleaseYear(int year )
        {
            this._releaseYear = year;
        }
        public void SetRating(string rating )
        {
            this._rating = rating;
        }
        public void SetGenre(string genre )
        {
            this._genre = genre;
        }
        public void SetIsColor(bool isColor )
        {
            this._isClassic = isColor;
        }
        public void SetDescription(string description )
        {
            this._description = description;
        }
        #endregion
    }
}
