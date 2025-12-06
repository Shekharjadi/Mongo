using Microsoft.AspNetCore.Mvc;

namespace SecretLeakWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretController : ControllerBase
    {
        // Intentionally exposed secrets
        private const string API_KEY = "API_KEY_1234567890abcdef9999999999";
        private const string JWT_SECRET = "JWT_SECRET_xxyyzz112233445566778899";
        private const string DB_PASSWORD = "dbPassword!@#1234567890";

        private readonly string AwsAccessKey = "AKIAFAKEKEY123456789";
        private readonly string AwsSecretKey = "FakeAWSSecretKey99999999999999";
        private readonly string StripeKey = "sk_test_FAKE_STRIPE_KEY_ABC123";
        private readonly string PrivateKeyBlock =
@"-----BEGIN PRIVATE KEY-----
MIIBVgIBADANBgkqhkiG9FAKEKEY...AAAAAA
-----END PRIVATE KEY-----";

        [HttpGet]
        public IActionResult GetSecrets()
        {
            return Ok(new
            {
                apiKey = API_KEY,
                jwt = JWT_SECRET,
                database = DB_PASSWORD,
                awsAccessKey = AwsAccessKey,
                awsSecretKey = AwsSecretKey,
                stripeKey = StripeKey,
                privateKey = PrivateKeyBlock
            });
        }
    }
}
