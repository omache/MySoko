using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySoko.Data;
using MySoko.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks; // Include Task and async
using Microsoft.AspNetCore.Identity;

namespace MySoko.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Inject the DbContext
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context; // Initialize the DbContext
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch products from the database
            var products = _context.Product.ToList(); // Sync operation

            // Fetch the first name of the signed-in user
            var user = await _userManager.GetUserAsync(User); // Async operation
            var firstName = user?.FirstName; // Handle possible null values
            
            ViewBag.FirstName = firstName;

            // Pass the products to the view
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
