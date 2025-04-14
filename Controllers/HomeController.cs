using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Hear_Read_WDT_Project.Models; // عدل على حسب اسم مشروعك

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _env;

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }
    
    public IActionResult Index()
    {
        var imageFolder = Path.Combine(_env.WebRootPath, "images");
        var images = Directory.GetFiles(imageFolder)
                              .Select(Path.GetFileName)
                              .Where(name => !string.IsNullOrEmpty(name) && !name.Contains("Logo-Hear&Read"))
                              .ToList();

        ViewBag.Images = images;

        var books = new List<Book>
{
    new Book { BookId = 1, Title = "The Power of Now", Author = "Eckhart Tolle", ImageUrl = "/images/photo1.jpeg", Description = "A guide to spiritual enlightenment." },
    new Book { BookId = 2, Title = "Atomic Habits", Author = "James Clear", ImageUrl = "/images/photo2.jpeg",  Description = "Build good habits and break bad ones." },
    new Book { BookId = 3, Title = "1984", Author = "George Orwell", ImageUrl = "/images/photo3.jpeg",  Description = "A dystopian social science fiction novel." },
    new Book { BookId = 4, Title = "Sapiens", Author = "Yuval Noah Harari", ImageUrl = "/images/photo4.jpeg",  Description = "A brief history of humankind." }
};
        return View(books);
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
