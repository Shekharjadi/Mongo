using Microsoft.AspNetCore.Mvc;
using Mongo_web.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Mongo_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Use relative path to access the file in wwwroot
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Secrets", "gitleaks_report.json");

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return Content("The JSON file does not exist at the specified location.");
            }

            // Read the file content
            var jsonContent = System.IO.File.ReadAllText(filePath);

            // Deserialize the JSON content into a list of GitleaksResult objects
            var results = JsonConvert.DeserializeObject<List<GitleaksResult>>(jsonContent);

            // Pass the data to the view
            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
