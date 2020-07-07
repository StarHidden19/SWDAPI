using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Dtos
{
    public class StudentTopicReadDto
    {
  
        public int studentTopicId { get; set; }
        public virtual int studentId { get; set; }
        public virtual int topicId { get; set; }
        public virtual TopicReadDto topic { get; set; }
    }
}
