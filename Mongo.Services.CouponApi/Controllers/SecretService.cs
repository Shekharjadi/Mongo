namespace Mongo.Services.CouponApi.Controllers
{
    public class SecretService
    {
        public object GetAllSecrets()
        {
            return new
            {
                AwsAccessKey = "AKIA123456789TESTKEY",
                GithubToken = "ghp_1234567890DUMMYTOKEN1234567890ABCD",
                SlackToken = "xoxb-123456789012-DUMMYTOKEN",
                JwtToken = "eyJhbGciOiJIUzI1NiJ9.DUMMY.DUMMY"
            };
        }
    }
}
