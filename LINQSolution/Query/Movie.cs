using System;

namespace Query
{
    class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        private int _year;
        public int Year
        {
            get
            {
                Console.WriteLine($"Returning year {_year} for movie {Title} ");
                return _year;

            }
            set
            {
                _year = value;
            }
        }
    }
}
