using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Dtos
{
    public class PostReadDto
    {

        public int postId { get; set; }
        public String content { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int topicId { get; set; }

    }
}
