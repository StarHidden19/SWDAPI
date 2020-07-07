using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public interface ITopicRepo
    {
        bool SaveChange();
        IEnumerable<Topic> GetAllTopic();
        Topic GetTopicById(int id);
        void CreateTopic(Topic topic);
        void UpdateTopic(Topic topic);
        void DeleteTopic(Topic topic);

    }
}
