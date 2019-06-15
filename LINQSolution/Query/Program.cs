using System;
using System.Collections.Generic;

namespace Query
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie{ Title = "The God Father", Rating = 4.3f, Year = 2017 },
                new Movie{ Title = "Manasam", Rating = 3.4f, Year = 2015 },
                new Movie{ Title = "Cochin Brothers", Rating = 5.0f, Year = 2014 },
                new Movie{ Title = "Appam muttai", Rating = 2.4f, Year = 2012 }
            };

            var result = movies
                            .Filter(m => m.Year > 2014);

            foreach (var movie in result)
                Console.WriteLine(movie.Title);

            Console.Read();
        }
    }
}
