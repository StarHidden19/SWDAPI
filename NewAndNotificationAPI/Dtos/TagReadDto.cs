using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Dtos
{
    public class TagReadDto
    {
        public int tagId { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public int topicId { get; set; }

        public virtual IEnumerable<PostTagsReadDto> PostTags { get; set; }
    }
}
