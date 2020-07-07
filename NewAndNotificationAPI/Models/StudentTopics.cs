using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Models
{
    public class StudentTopics
    {
        [Key]
        public int studentTopicId { get; set; }
        [Required]
        public int studentId { get; set; }
        [Required]
        public Student student { get; set; }
        [Required]
        public int topicId { get; set; }
        [Required]
        public Topic topic { get; set; }

    }
}
