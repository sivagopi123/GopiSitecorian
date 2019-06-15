using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Dtos
{
    public class MoviesDto
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


        public GenreDto Genre { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}