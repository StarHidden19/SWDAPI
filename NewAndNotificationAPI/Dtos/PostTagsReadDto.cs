using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Dtos
{
    public class PostTagsReadDto
    {
        public int PostTagId { get; set; }
        public int postId { get; set; }
        public int tagId { get; set; }

        public virtual PostReadDto post { get; set; }
    }
}
