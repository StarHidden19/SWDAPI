using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Models
{
    public class Post
    {
        [Key]
        public int postId { get; set; }
        [Required]
        public String content { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public int topicId { get; set; }
        [Required]
        public virtual Topic topic { get; set; }
        public virtual IEnumerable<PostTags> PostTags { get; set; }
    }
}
