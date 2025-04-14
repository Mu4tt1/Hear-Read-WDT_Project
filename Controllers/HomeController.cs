using System.Diagnostics;
using Hear_Read_WDT_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hear_Read_WDT_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IActionResult Index()
        {
            var books = new List<Book>
        {
            new Book { BookId = 1, Title = "The Power of Now", Author = "Eckhart Tolle", ImageUrl = "https://via.placeholder.com/300x400?text=Book+1" },
            new Book { BookId = 2, Title = "Atomic Habits", Author = "James Clear", ImageUrl = "https://via.placeholder.com/300x400?text=Book+2" },
            new Book { BookId = 3, Title = "1984", Author = "George Orwell", ImageUrl = "https://via.placeholder.com/300x400?text=Book+3" },
            new Book { BookId = 4, Title = "Sapiens", Author = "Yuval Noah Harari", ImageUrl = "https://via.placeholder.com/300x400?text=Book+4" }
        };

            return View(books);
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
