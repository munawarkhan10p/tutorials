using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "MVCApp"};
            var customers = new List<Customer>
            { 
                new Customer {Name="Customer1" },
                 new Customer {Name="Customer2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie =movie,
                Customer = customers 
            };

           return View(viewModel);
            //return Content("Hello World");
           // return HttpNotFound();
           //return new EmptyResult();
           // return RedirectToAction("Index", "Home",new {PageSize=10,OrderBy="Name"});
        }
        public ActionResult Edit(int Id)
        {
            return Content("movieID" + Id);
        }

        public ActionResult Index(int? PageIndex, string SortBy)
        {
            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (string.IsNullOrEmpty(SortBy))
                SortBy = "Name";
            return Content(string.Format("PageIndex={0} and SortBy={1}", PageIndex, SortBy));
        }

        [Route("Movies/Release/{year}/{month}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}