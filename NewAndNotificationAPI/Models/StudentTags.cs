using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Models
{
    public class StudentTags
    {
        [Key]
        public int StudentTagId { get; set; }
        public int studentId { get; set; }
        public Student student { get; set; }

        public int tagId { get; set; }
        public Tag tag { get; set; }



    }
}
