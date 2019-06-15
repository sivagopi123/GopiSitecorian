using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NoInStock { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
        public int NumberAvailable { get; set; }
    }
}