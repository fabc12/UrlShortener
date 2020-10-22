namespace Application.ViewModels
{
    public class GetOriginalLinkViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string ShortLink { get; set; }
        }

        public class Response
        {
            public string OriginalLink { get; set; }
        }
    }
}