using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    [AllowAnonymous]
    public class MoviesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            return View();
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

        public ActionResult SaveorUpdateMovie()
        {
            return View("MovieDetails");
        }
    }
}