
using System;
using MovieLib.Memory;

namespace MovieLib
{
    public class SeedDatabase
    {
        public void Seed (IMovieDatabase database)
        {
            database.Add(new Movie {
                Title = "Jaws",
                Genre = "Horror",
                ReleaseYear = 1977,
                Duration = 124,
                Rating = "PG",
                IsClassic = true
            });

            database.Add(new Movie {
                Title = "The Rise of Danzu",
                Genre = "Horror, Action",
                ReleaseYear = 2019,
                Duration = 145,
                Rating = "R",
                IsClassic = true
            });

            database.Add(new Movie {
                Title = "Where Dragons Fly...",
                Genre = "Action, Adventure",
                ReleaseYear = 2020,
                Duration = 139,
                Rating = "PG",
                IsClassic = true
            });

            database.Add(new Movie {
                Title = "Danzu versus the Lycan",
                Genre = "Action, Horror",
                ReleaseYear = 2021,
                Duration = 157,
                Rating = "PG-13",
                IsClassic = true
            });

            database.Add(new Movie {
                Title = "Mutant Soldiers",
                Genre = "Action",
                ReleaseYear = 2022,
                Duration = 149,
                Rating = "PG-13",
                IsClassic = true
            });

            database.Add(new Movie {
                Title = "Danzu's Return",
                Genre = "Horror",
                ReleaseYear = 2024,
                Duration = 179,
                Rating = "R",
                IsClassic = false
            });

            database.Add(new Movie {
                Title = "Mutant Soldiers 2",
                Genre = "Action",
                ReleaseYear = 2025,
                Duration = 158,
                Rating = "PG-13",
                IsClassic = false
            });

            database.Add(new Movie {
                Title = "Fall of the Mutant Soldiers",
                Genre = "Action",
                ReleaseYear = 2028,
                Duration = 167,
                Rating = "PG-13",
                IsClassic = false
            });

            database.Add(new Movie {
                Title = "Return of the Mutant Soldiers",
                Genre = "Action",
                ReleaseYear = 2031,
                Duration = 178,
                Rating = "R",
                IsClassic = true
            });

        }
    }
}
