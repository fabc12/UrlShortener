using System.Collections.Generic;

namespace Application.Dtos
{
    public class GetShortUrlsDto
    {
        public ICollection<string> ShortUrls { get; set; }
    }
}