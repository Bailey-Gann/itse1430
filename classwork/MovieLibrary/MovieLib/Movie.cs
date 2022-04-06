﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLib
{
    /// <summary>Represents a movie.</summary>
    public class Movie : IValidatableObject
    {
        /// <summary>Gets the minimum release year.</summary>
        public const int MinimumReleaseYear = 1900;

        /// <summary>Gets the minimum release date.</summary>
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

        /// <summary>Gets or sets the title of the movie.</summary>
        public string Title
        {
            //get { return !String.IsNullOrEmpty(_title) ? _title : ""; }
            //get { return (_title != null) ? _title : ""; }
            get { return _title ?? ""; }

            //set { _title = (value != null ) ? value.Trim() : null; }
            //set { _title = (value ?? "").Trim(); }
            set { _title = value?.Trim(); }
        }
        private string _title;

        //Auto property syntax when property is simply reading/writing backing field
        /// <summary>Gets or sets the duration in minutes.</summary>
        public int Duration { get; set; }

        /// <summary>Gets or sets the release year.</summary>
        public int ReleaseYear { get; set; } = 1900;
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;

        /// <summary>Gets or sets the rating.</summary>
        public string Rating
        {
            get { return !String.IsNullOrEmpty(_rating) ? _rating : ""; }
            set { _rating = value; }
        }
        private string _rating;

        /// <summary>Gets or sets the genre.</summary>
        public string Genre
        {
            get { return !String.IsNullOrEmpty(_genre) ? _genre : ""; }
            set { _genre = value; }
        }
        private string _genre;

        /// <summary>Gets or sets if the movie is a classic.</summary>
        public bool IsClassic { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return !String.IsNullOrEmpty(_description) ? _description : ""; }
            set { _description = value; }
        }
        private string _description;

        //Calculated property := BW <= 1939
        // No setter so it cannot be written to
        /// <summary>Determines if the movie is black and white.</summary>
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear <= 1939; }
            //set { }
        }
        //private bool _isBlackAndWhite;

        //private void CalculateBlackAndWhite ()
        //{
        //    _isBlackAndWhite = ReleaseYear <= 1939;
        //}

        //All instance methods have a hidden this parameter that represents the instance
        
       

        /// <summary>Gets the unique ID of the movie.</summary>
        public int Id { get; set; }
        //{
        //    get { return _id; }
        //    private set { _id = value; }
        //}
        //private int _id;
        public override string ToString ()
        {
            return $"{Title} ({ReleaseYear})";
        }


        public Movie Copy ()
        {
            //var item = new Movie();
            //item.Id = Id;            

            //item.Title = Title;
            //item.Description = Description;
            //item.Duration = Duration;
            //item.ReleaseYear = ReleaseYear;
            //item.Rating = Rating;
            //item.Genre = Genre;
            //item.IsClassic = IsClassic;
            //return item;

            //Object initializer syntax
            // Only works with new
            // Steps:
            //  1. Remove semicolon at end of new, add curly braces
            //  2. Indent for readability
            //  3. Replace semicolons with commas
            //  4. Remove instance name
            return new Movie() {
                    Id = Id,
                    Title = Title,
                    Description = Description,
                    Duration = Duration,
                    ReleaseYear = ReleaseYear,
                    Rating = Rating,
                    Genre = Genre,
                    IsClassic = IsClassic,
                     };
            
        }

        public void CopyFrom ( Movie source )
        {            
            Title = source.Title;
            Description = source.Description;
            Duration = source.Duration;
            ReleaseYear = source.ReleaseYear;
            Rating = source.Rating;
            Genre = source.Genre;
            IsClassic = source.IsClassic;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(_title))
                yield return new ValidationResult("Title is required", new[] {nameof(Title) });

            if (Duration < 0)
                //if (this.duration < 0)
                yield return new ValidationResult("Duration must be at least 0", new[] { nameof(Duration) });

            if (ReleaseYear < MinimumReleaseYear)
                yield return new ValidationResult($"Release Year must be at least {MinimumReleaseYear}", new[] { nameof(ReleaseYear) });

            if (String.IsNullOrEmpty(Rating))
                yield return new ValidationResult("Rating is required", new[] { nameof(Rating) });

           
        }
    }
   

    #region Class Notes
    // Class - wraps data and functionality
    //   Naming: nouns, Pascal cased
    //   Default accessibility: internal for a class, private for a class member    

    //Access modifiers
    //  public - everyone
    //  internal - assembly only
    //  private - declaring type

    //Fields - where the data is stored
    // Naming: nouns, camel cased, start with underscore
    //   Readable and writable (assuming accessibility)
    //   Work just like all other variables
    // Do not expose publicly

    //Properties - exposes data
    //  Field syntax with methods being called
    //  Can get (read) and/or set (write)
    //    T getter ()
    //    void setter ( T value )
    //  Mixed acessibility
    //    Only on either getter or setter
    //    Must be more restrictive than property
    //  property-declaration ::= [access] [modifiers] T id { accessors }    
    //  accessors ::= full-accessors | auto-accessors
    //  full-accessors ::= [[access] get { S* }] [[access] set { S* }]
    //  auto-accessors ::= [[access] get;] [[access] set;]

    // Handling null
    //   null coalescing ::= E ?? E, find first non-null
    //   null conditional ::= E?.M, execute M if E not null, changes type to T?
    //   combined ::= E?.M ?? D, resets type back to T            
    #endregion
}
