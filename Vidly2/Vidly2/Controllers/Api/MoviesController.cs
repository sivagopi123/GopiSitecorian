using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/movies/
        public IEnumerable<MoviesDto> GetMovies(string Query = null)
        {
            var moviesQuery = _context.Movie
                                .Include(m => m.Genre)
                                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrEmpty(Query))
                moviesQuery = moviesQuery
                                    .Where(m => m.MovieName.Contains(Query));

            var moviesDto = moviesQuery
                            .ToList().Select(Mapper.Map<Movie, MoviesDto>);

            return moviesDto;
        }

        //GET /api/movies/1
        public MoviesDto GetMovie(int id)
        {
            var movieInDB = _context.Movie.SingleOrDefault(m => m.MovieId == id);
            return Mapper.Map<Movie, MoviesDto>(movieInDB);
        }

        //POST /api/movies/
        [HttpPost]
        public MoviesDto CreateMovie(MoviesDto moviedto)
        {
            var movie = Mapper.Map<MoviesDto, Movie>(moviedto);
            _context.Movie.Add(movie);
            _context.SaveChanges();
            moviedto.MovieId = movie.MovieId;
            return moviedto;
        }

        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MoviesDto moviesDto)
        {
            var movieInDB = _context.Movie.SingleOrDefault(m => m.MovieId == id);

            Mapper.Map(movieInDB, moviesDto);
            _context.SaveChanges();

        }

        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDB = _context.Movie.SingleOrDefault(m => m.MovieId == id);

            _context.Movie.Remove(movieInDB);
            _context.SaveChanges();
        }
    }
}
