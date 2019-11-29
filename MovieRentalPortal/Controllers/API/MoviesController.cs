using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieRentalPortal.Dtos;
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
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return movies;
        }

        //GET --> /api/movies/1
        [HttpGet]
        [Route("api/Movies/{movieId}")]
        public IHttpActionResult GetMovies(int movieId)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == movieId);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST --> /api/customer
        [HttpPost]
        public IHttpActionResult AddNewMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.MovieId = movie.MovieId;

            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movieDto);
        }

        //PUT --> modiy/update --> /api/customer/1
        [HttpPut]
        [Route("api/Movies/{movieId}")]
        public IHttpActionResult UpdateCustomer(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.Single(m => m.MovieId == movieDto.MovieId);

            if (movieInDb == null)
                return NotFound();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            //movieInDb.MovieName = movie.MovieName;
            //movieInDb.ReleaseDate = movie.ReleaseDate;
            //movieInDb.NumberInStock = movie.NumberInStock;
            //movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();

            return Ok(movie);
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

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
    }
}
