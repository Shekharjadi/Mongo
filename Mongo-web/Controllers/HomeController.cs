using Microsoft.AspNetCore.Mvc;
using Mongo_web.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;

namespace Mongo_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page = 1, string sortBy = "File", string searchQuery = "")
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Secrets", "gitleaks_report.json");
            var model = new GitleaksViewModel();

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                model.Results = new List<GitleaksResult>();  // No data available
                model.Message = "The JSON file does not exist at the specified location.";  // Set error message
                return View(model);
            }

            var jsonContent = System.IO.File.ReadAllText(filePath);
            var results = JsonConvert.DeserializeObject<List<GitleaksResult>>(jsonContent);

            // Filter the results based on the search query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                results = results.Where(r => r.File.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                              r.Commit.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                              r.Secret.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sort the results
            results = sortBy switch
            {
                "Commit" => results.OrderBy(r => r.Commit).ToList(),
                "Secret" => results.OrderBy(r => r.Secret).ToList(),
                "Link" => results.OrderBy(r => r.Link).ToList(),
                _ => results.OrderBy(r => r.File).ToList(),
            };

            // Pagination logic
            int pageSize = 10; // Number of items per page
            var pagedResults = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            model.Results = pagedResults;
            model.Message = results.Any() ? null : "No data available.";  // If no data, set message
            model.CurrentPage = page;
            model.TotalResults = results.Count;
            model.PageSize = pageSize;
            model.SearchQuery = searchQuery;
            model.SortBy = sortBy;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
