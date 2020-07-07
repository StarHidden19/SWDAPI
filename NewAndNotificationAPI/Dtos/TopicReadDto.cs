using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewAndNotificationAPI.Dtos
{
    public class TopicReadDto
    {
        [Key]
        public int topicId { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public IEnumerable<TagReadDto> tags { get; set; }
        public IEnumerable<PostReadDto> posts { get; set; }
    }

}
