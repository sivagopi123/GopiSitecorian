using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenre();
    }
}