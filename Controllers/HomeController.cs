using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySoko.Data;
using MySoko.Models;
using System.Diagnostics;
using System.Linq;

namespace MySoko.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Inject the DbContext

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Initialize the DbContext
        }

        public IActionResult Index()
        {
            // Fetch products from the database
            var products = _context.Product.ToList();
            return View(products);
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
