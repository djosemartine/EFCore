using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Author
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}