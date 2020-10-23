using Application.Dtos;

namespace Application.ViewModels
{
    public class GetShortUrlsViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class Response
        {
            public GetShortUrlsDto GetShortUrlsDto { get; set; }
        }
    }
}