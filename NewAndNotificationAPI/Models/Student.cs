using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string major { get; set; }
        [Required]
        public string className { get; set; }
        [Required]
        public string curriculum { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public int phoneNumber { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }

        public virtual IEnumerable<StudentTopics> StudentTopics { get; set; }
        public virtual IEnumerable<StudentTags> StudentTags { get; set; }
    }
}
