using System.Collections.Generic;
using Domain.Entities;

namespace Application.ViewModels
{
    public class GetLinksViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class Response
        {
            public IList<LinkMapper> Links;
        }
    }
}