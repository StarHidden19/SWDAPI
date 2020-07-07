using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Dtos
{
    public class StudentTagReadDto
    {
        public int StudentTagId { get; set; }
        public int studentId { get; set; }

        public int tagId { get; set; }

        public virtual TagReadDto tag { get; set; }
    }
} 
