using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly2.Models;
using Vidly2.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller

    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
       
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieViewModel = new MovieFormViewModel()
            {
                Genre = genres
            };

            ViewBag.Title = "New Movie";
            return View("MovieForm", movieViewModel );
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieFormViewModel(movie)
            {
                
                Genre = _context.Genres.ToList()

            };
            return View("MovieForm", movieViewModel);
        }

       
        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel(movie)
                {
                 
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", movieFormViewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.NumberInStock = movie.NumberInStock;
                movieInDB.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
       
        }

        public ActionResult show(int Id)
        {
            return View();
        }

      
       
    }
}