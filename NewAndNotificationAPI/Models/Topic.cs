using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewAndNotificationAPI.Models
{
    public class Topic
    {
        [Key]
        public int topicId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string description { get; set; }
        
        public virtual IEnumerable<Tag> tags { get; set; }

        public virtual IEnumerable<Post> posts { get; set; }

        public virtual IEnumerable<StudentTopics> StudentTopics { get; set; }
    }
}
