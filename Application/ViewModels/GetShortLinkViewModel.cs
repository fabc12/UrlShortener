namespace Application.ViewModels
{
    public class GetShortLinkViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string OriginalLink { get; set; }
        }

        public class Response
        {
            public string ShortLink { get; set; }
        }
    }
}