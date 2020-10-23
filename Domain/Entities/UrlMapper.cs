using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UrlMapper
    {
        public string Email { get; set; }
        [ForeignKey("Email")]
        
        [Required]
        public string OriginalUrl { get; set; }
        [Key]
        public string ShortUrl { get; set; }
    }
}