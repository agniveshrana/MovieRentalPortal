using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRentalPortal.Models;

namespace MovieRentalPortal.Controllers.API
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET --> /api/movies
        [HttpGet]
        public IEnumerable<Customer> GetMovies()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        //GET --> /api/movies/1
        [HttpGet]
        [Route("api/Movies/{movieId}")]
        public IHttpActionResult GetMovies(int movieId)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == movieId);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        //POST --> /api/customer
        [HttpPost]
        public IHttpActionResult AddNewMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movie);
        }

        //PUT --> modiy/update --> /api/customer/1
        [HttpPut]
        [Route("api/Movies/{movieId}")]
        public IHttpActionResult UpdateCustomer(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.Single(m => m.MovieId == movie.MovieId);

            if (movieInDb == null)
                return NotFound();

            movieInDb.MovieName = movie.MovieName;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();

            return Ok(movieInDb);
        }

        //DELETE --> api/customer/1
        [HttpDelete]
        [Route("api/Movies/{movieId}")]
        public IHttpActionResult DeleteMovie(int movieId)
        {
            var movieInDb = _context.Movies.Single(m => m.MovieId == movieId);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok(movieInDb);
        }
    }
}
