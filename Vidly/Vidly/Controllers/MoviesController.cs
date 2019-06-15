using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        VidlyContext db = new VidlyContext();
        // GET: Movies
        public ActionResult Random()
        {
            var viewModel = new RandomMovieViewModel
            {
                Movie = db.Movie.Include(m => m.Genre).ToList()
            };
            return View(viewModel);
        }
        public MovieFormViewModel GetMovieViewModel(Movie movie)
        {
            var movieViewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = db.Genre.ToList()
            };
            movieViewModel.Movie.Genre = movie.Genre;
            return movieViewModel;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(movie.ToString())))
            {
                var MovieInDB = db.Movie.Include(m => m.Genre).FirstOrDefault(m => m.MovieId == movie.MovieId);
                if (MovieInDB != null)
                {
                    MovieInDB.MovieName = movie.MovieName;
                    MovieInDB.NoInStock = movie.NoInStock;
                    MovieInDB.ReleaseDate = movie.ReleaseDate;
                    MovieInDB.DateAdded = movie.DateAdded;
                    MovieInDB.Genre = movie.Genre;
                    try
                    {
                        db.SaveChanges();
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    return View("MovieDetails", GetMovieViewModel(movie));
                }
                else
                {
                    var newmovie = new Movie();
                    newmovie.MovieName = movie.MovieName;
                    newmovie.NoInStock = movie.NoInStock;
                    newmovie.ReleaseDate = movie.ReleaseDate;
                    newmovie.DateAdded = movie.DateAdded;
                    newmovie.Genre = movie.Genre;
                    db.Movie.Add(newmovie);
                    db.SaveChanges();
                    return View("MovieDetails", GetMovieViewModel(movie));
                }
            }
            else
            {
                //var newmovie = new Movie();
                //newmovie.MovieName = movie.MovieName;
                //newmovie.NoInStock = movie.NoInStock;
                //newmovie.ReleaseDate = movie.ReleaseDate;
                //newmovie.DateAdded = movie.DateAdded;
                //newmovie.Genre = movie.Genre;
                db.Movie.Add(movie);
                db.SaveChanges();
                return View("MovieDetails", GetMovieViewModel(movie));
            }
        }
        [Route("Movies/Details/{Id:Regex(\\d)}")]
        public ActionResult Details(int Id)
        {
            var Movie = db.Movie.Include(m => m.Genre).FirstOrDefault(m => m.MovieId == Id);
            return View(Movie);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            return Content(string.Format("PageIndex = {0} <br/>  Sort By = {1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4}):range(2000,2018)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult MovieForm(int? Id)
        {
            var Movie = db.Movie.Include(m => m.Genre).FirstOrDefault(m => m.MovieId == Id);
            return View(Movie);
        }

        public ActionResult MovieDetails(int? Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                var Movie = db.Movie.Include(m => m.Genre).FirstOrDefault(m => m.MovieId == Id);
                if (Movie != null)
                {
                    MovieFormViewModel viewModel = new MovieFormViewModel
                    {
                        Movie = Movie,
                        Genres = db.Genre.ToList()
                    };
                    return View(viewModel);
                }
                else
                {
                    MovieFormViewModel viewModel = new MovieFormViewModel
                    {
                        Movie = new Movie(),
                        Genres = db.Genre.ToList()
                    };
                    return View(viewModel);
                }
            }
            else
            {
                MovieFormViewModel viewModel = new MovieFormViewModel
                {
                    Movie = new Movie(),
                    Genres = db.Genre.ToList()
                };
                return View(viewModel);
            }

        }

    }
}