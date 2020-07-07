using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public class SqlStudentTagsRepo : IStudentTagRepo
    {
        private NewAndNotificationContext _context;

        public SqlStudentTagsRepo(NewAndNotificationContext context)
        {
            _context = context;
        }
        public void CreateStudentTags(StudentTags studentTags)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudentTags(StudentTags studentTags)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentTags> GetAllStudentTags()
        {
            IEnumerable<StudentTags> studentTags = _context.StudentTags.Include(t => t.tag).ToList();
            return studentTags;
        }

        public StudentTags GetStudentTagsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentTags(StudentTags studentTags)
        {
            throw new NotImplementedException();
        }
    }
}
