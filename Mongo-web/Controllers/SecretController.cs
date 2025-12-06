using Microsoft.AspNetCore.Mvc;

namespace Mongo_web.Controllers
{
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            // GitLab tokens
            string gitlabToken = "glpat-1234567890abcdefghijklmnopqrstuvwxyz";

            // Heroku API key
            string herokuApiKey = "3a1a1234-567b-89cd-ef01-23456789abcd";

            // Dropbox API Key
            string dropboxKey = "sl.ABcdefGhijkLMNOPQRSTuvwxYZ1234567890abcd";

            // DigitalOcean API Key
            string digitalOceanKey = "dop_v1_1234567890abcdefghijklmnopqrstuvwxyz";

            // Fake SSH key
            string sshPrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIICWwIBAAKBgHABCDEFG1234567890ABCDEFGH1234567890ABCDEFGH12345
-----END RSA PRIVATE KEY-----";

            // Fake Private Key
            string privateKey = "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BA...\n-----END PRIVATE KEY-----";

            // Bitcoin wallet private key format
            string btcPrivateKey = "5HueCGU8rMjxEXxiPuD5BDuJNh4y...FAKE";

            ViewBag.GitLab = gitlabToken;
            ViewBag.SSH = sshPrivateKey;
            ViewBag.BTC = btcPrivateKey;

            return View();
        }
    }
}
