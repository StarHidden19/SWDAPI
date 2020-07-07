using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Dtos
{
    public class StudentReadDto
    {
        public int studentId { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string major { get; set; }
        public string className { get; set; }
        public string curriculum { get; set; }
        public string address { get; set; }
        public int phoneNumber { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }

        public virtual IEnumerable<StudentTopicReadDto> StudentTopics { get; set; }
        public virtual IEnumerable<StudentTagReadDto> StudentTags { get; set; }
    }
}
