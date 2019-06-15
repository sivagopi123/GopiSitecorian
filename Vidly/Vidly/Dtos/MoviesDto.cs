using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
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
        [Required]
        public int GenreId { get; set; }
    }
}