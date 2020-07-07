using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public class SqlStudentTopicRepo : IStudentTopicRepo
    {
        private NewAndNotificationContext _context;

        public SqlStudentTopicRepo(NewAndNotificationContext context)
        {
            _context = context;
        }
        public void CreateStudentTopics(StudentTopics studentTopics)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudentTopic(StudentTopics studentTopics)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentTopics> GetAllStudentTopics()
        {
            IEnumerable<StudentTopics> studentTopics = _context.StudentTopics.Include(t=> t.topic).ToList();
            return studentTopics;
        }

        public Student GetStudentTopicsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentTopic(StudentTopics studentTopics)
        {
            throw new NotImplementedException();
        }
    }
}
