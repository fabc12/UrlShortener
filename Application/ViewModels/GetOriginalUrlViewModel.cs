namespace Application.ViewModels
{
    public class GetOriginalUrlViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string ShortUrl { get; set; }
        }

        public class Response
        {
            public string OriginalUrl { get; set; }
        }
    }
}