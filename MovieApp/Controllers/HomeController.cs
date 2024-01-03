using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WatchList()                        //Read
        {
            IEnumerable<Movie> wathclist = _db.Movies;
            return View(wathclist);
        }
        //Get
        [HttpGet]                                               //Create [Get]
        public IActionResult CreateWatchlist()
        {
            return View();
        }

        //Post
        [HttpPost]                                              //Create [Post]
        [ValidateAntiForgeryToken]
        public IActionResult CreateWatchlist(Movie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie added successfully";
                return RedirectToAction("Watchlist");
            }
            return View(obj);
        }



        //Get
        public IActionResult EditWatchlist(int? id)             //Edit [Get]
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var movieId = _db.Movies.Find(id);

            if(movieId == null)
            {
                return NotFound();
            }

            return View(movieId);
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWatchlist(Movie obj)           //Edit [Post]
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie edited successfully";
                return RedirectToAction("Watchlist");
            }
            return View(obj);
        }


        //Get
        public IActionResult DeleteWatchlist(int? id)           //Delete [Get]
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var movieId = _db.Movies.Find(id);

            if (movieId == null)
            {
                return NotFound();
            }

            return View(movieId);
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteWatchlistPost(int? id)       //Delete [Post]
        {
            var obj = _db.Movies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Movies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Movie deleted successfully";
            return RedirectToAction("Watchlist");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}