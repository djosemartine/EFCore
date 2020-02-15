using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Author> Author { get; set; }
    }
}
