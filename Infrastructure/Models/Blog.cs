using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Blog
    {
        [Required]
        public Guid Id { get; set; }
        [EnumDataType(typeof(BlogStatus))]
        public BlogStatus Status { get; set; }
        [Required]
        [Url]
        [MaxLength(255)]
        public string Url { get; set; }
        public ICollection<Post> Posts { get; set; }
        [Required]
        public long CaptureDateUTC { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
