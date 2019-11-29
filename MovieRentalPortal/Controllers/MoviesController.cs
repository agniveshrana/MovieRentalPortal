using MovieRentalPortal.Models;
using MovieRentalPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MovieRentalPortal.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Movies")]
        [Route("Movies/Index")]
        public ActionResult Index()
        {
            MovieViewModel movieVM = new MovieViewModel();
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            movieVM.MovieList = movies;

            if (User.IsInRole(RoleName.ADMIN))
                return View(movieVM);

            return View("ReadOnlyMovie", movieVM);
        }

        [Route("Movies/Details/{MovieId}")]
        public ActionResult Details(int movieId)
        {
            var movieVM = new MovieFormViewModel()
            {
                Movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.MovieId == movieId),
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieVM);
        }

        [Route("Movies/New")]
        public ActionResult New()
        {
            var movieVM = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieVM = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", movieVM);
            }
            if (movie.MovieId == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var moviesInDb = _context.Movies.Single(m => m.MovieId == movie.MovieId);

                moviesInDb.MovieName = movie.MovieName;
                moviesInDb.ReleaseDate = movie.ReleaseDate;
                moviesInDb.NumberInStock = movie.NumberInStock;
                moviesInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}