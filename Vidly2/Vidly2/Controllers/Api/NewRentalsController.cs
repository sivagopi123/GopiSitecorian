using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0 || newRental is null)
                return BadRequest("No Movies Added");

            var customer = _context.Customer.SingleOrDefault(c => c.CustomerId == newRental.CustomerId);
            var movies = _context.Movie.Where(m => newRental.MovieIds.Contains(m.MovieId)).ToList();

            if (customer == null)
                return BadRequest("Customer Id not valid");

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movie Id is invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest(string.Format("Movie {0} is not available", movie.MovieName));

                movie.NumberAvailable--;
                var rentalRecord = new Rental
                {
                    CustomerRented = customer,
                    MoviesRented = movie,
                    DateRented = DateTime.Now,
                    DateReturned = null
                };
                _context.Rentals.Add(rentalRecord);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
