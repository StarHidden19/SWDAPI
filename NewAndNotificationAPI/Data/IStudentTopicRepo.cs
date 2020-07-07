using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public interface IStudentTopicRepo
    {
        bool SaveChange();
        IEnumerable<StudentTopics> GetAllStudentTopics();
        Student GetStudentTopicsById(int id);
        void CreateStudentTopics(StudentTopics studentTopics);
        void UpdateStudentTopic(StudentTopics studentTopics);
        void DeleteStudentTopic(StudentTopics studentTopics);
    }
}
