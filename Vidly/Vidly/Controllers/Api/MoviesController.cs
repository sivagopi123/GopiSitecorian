using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private VidlyContext _context;
        public MoviesController()
        {
            _context = new VidlyContext();
        }

        //GET /api/movies/
        public IEnumerable<MoviesDto> GetMovies()
        {
            return _context.Movie.ToList().Select(Mapper.Map<Movie, MoviesDto>);
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
