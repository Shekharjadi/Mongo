namespace Mongo_web.Models
{
    public class GitleaksViewModel
    {
        public List<GitleaksResult> Results { get; set; }
        public int CurrentPage { get; set; }
        public int TotalResults { get; set; }
        public int PageSize { get; set; }
        public string SearchQuery { get; set; }
        public string SortBy { get; set; }
        public string Message { get; set; }
    }
}
