using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace Mongo_web.Controllers
{
    public class FileController : Controller
    {
        // Endpoint to open a file in Visual Studio
        [HttpGet]
        [Route("api/OpenFile")]
        public IActionResult OpenFile(string path)
        {
            try
            {
                // Specify the full path to Visual Studio (devenv.exe) - update if necessary
                string visualStudioPath = @"C:\Program Files\Microsoft Visual Studio\18\Community\Common7\IDE\devenv.exe";  // Update this if needed

                // Full path to the file you want to open
                string filePath = Path.Combine(@"C:\Users\development\source\repos\Mongo-web", path);

                // Log the full path for debugging
                Console.WriteLine($"Attempting to open file at: {filePath}");

                string solutionPath = Path.Combine(@"C:\Users\development\source\repos\Mango-web\Mongo.slnx");

                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = visualStudioPath,
                    Arguments = $"\"{filePath}\"",
                    CreateNoWindow = true
                };

                Process.Start(processInfo);


                return Ok("File opened in Visual Studio.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error opening file: {ex.Message}");
            }
        }
    }
}
