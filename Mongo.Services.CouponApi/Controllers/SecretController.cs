using Microsoft.AspNetCore.Mvc;
using Mongo.Services.CouponApi.Controllers;  // Make sure this is the correct namespace for SecretService

namespace Mongo.Services.CouponApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecretsController : ControllerBase
    {
        private readonly SecretService _service;

        // Constructor to inject SecretService
        public SecretsController(SecretService service)
        {
            _service = service;
        }

        [HttpGet("dummy")]
        public IActionResult GetDummySecrets()
        {
            var secrets = _service.GetAllSecrets();  // Get the secrets from the service

            if (secrets == null)
            {
                return NotFound("No secrets found.");
            }

            return Ok(secrets);  // Return the secrets as a response
        }
    }
}
