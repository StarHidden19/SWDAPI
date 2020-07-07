using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public interface IStudentRepo
    {
        bool SaveChange();
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
