using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRentalPortal.Models;
using MovieRentalPortal.Dtos;

namespace MovieRentalPortal.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Route("api/NewRentals")]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto)
        {
            var customer = _context.Customers.Single(c => c.CustomerId == rentalDto.CustomerId);

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.MovieId));

            foreach (var movie in movies)
            {
                if (movie.RemainingQty == 0)
                    BadRequest("This movie is out of stock");

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                movie.RemainingQty--;
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
