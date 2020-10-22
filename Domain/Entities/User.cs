using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LinkMapper
    {
        public string Email { get; set; }
        [ForeignKey("Email")]

        public string OriginalLink { get; set; }
        [Key]
        public string ShortLink { get; set; }
    }
}