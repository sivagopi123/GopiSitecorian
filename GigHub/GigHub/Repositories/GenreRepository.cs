using GigHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public ApplicationDbContext _context { get; set; }

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> GetGenre()
        {
            return _context.Genres.ToList();
        }
    }
}