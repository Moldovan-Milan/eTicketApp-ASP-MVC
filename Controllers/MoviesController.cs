using eTicketApp.Data;
using eTicketApp.Data.Services;
using eTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace eTicketApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAllOrderbyAsync();
            if (movies == null) 
                return View("NotFound");
            return View(movies);
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

        // Get: Filter/searchString
        public async Task<IActionResult> Filter(string searchString)
        {
            // Ha üres, visszatér az index
            if (string.IsNullOrEmpty(searchString))
                return RedirectToAction("Index");

            var filteredMovies = await _service.SearchByNameAsync(searchString);
            if (filteredMovies == null)
                return View("NotFound");
            return View("Index", filteredMovies);
        }
    }
}
