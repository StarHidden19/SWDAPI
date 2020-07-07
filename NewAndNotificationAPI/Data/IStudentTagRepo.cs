using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public interface IStudentTagRepo
    {
        bool SaveChange();
        IEnumerable<StudentTags> GetAllStudentTags();
        StudentTags GetStudentTagsById(int id);
        void CreateStudentTags(StudentTags studentTags);
        void UpdateStudentTags(StudentTags studentTags);
        void DeleteStudentTags(StudentTags studentTags);
    }
}
