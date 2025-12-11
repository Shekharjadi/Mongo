namespace Mongo_web.Models
{
    public class GitleaksResult
    {
        public string RuleID { get; set; }
        public string Description { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public string Match { get; set; }
        public string Secret { get; set; }
        public string File { get; set; }
        public string Commit { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string Fingerprint { get; set; }
    }

}
