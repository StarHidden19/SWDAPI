using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Models
{
    public class PostTags
    {
        [Key]
        public int PostTagId { get; set; }
        [Required]
        public int postId { get; set; }
        [Required]
        public virtual Post post { get; set; }
        [Required]
        public int tagId { get; set; }
        [Required]
        public virtual Tag tag { get; set; }
    }
}
