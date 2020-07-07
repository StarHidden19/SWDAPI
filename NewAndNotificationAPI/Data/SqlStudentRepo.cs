using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public class SqlStudentRepo : IStudentRepo
    {
        private NewAndNotificationContext _context;

        public SqlStudentRepo(NewAndNotificationContext context)
        {
            _context = context;
        }
        public void CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            IEnumerable<Student> students = _context.Students.Include(st => st.StudentTopics).ThenInclude(t=>t.topic)
                                                    .Include(st => st.StudentTags).ThenInclude(tg => tg.tag)
                                                    .ToList();

            return students;
        }

        public Student GetStudentById(int id)
        {
            Student student = _context.Students.Include(st => st.StudentTopics).ThenInclude(t => t.topic)
                                                .Include(st => st.StudentTags).ThenInclude(tg => tg.tag)
                                                .ToList().FirstOrDefault(s => s.studentId == id);
            //IEnumerable<StudentTopics> studentTopics = _context.StudentTopics.Include(t => t.topic).ToList();
            return student;
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
