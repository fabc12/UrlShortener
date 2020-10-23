namespace Application.ViewModels
{
    public class GetShortUrlViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string OriginalUrl { get; set; }
        }

        public class Response
        {
            public string ShortUrl { get; set; }
        }
    }
}