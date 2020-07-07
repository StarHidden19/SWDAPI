using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public class SqlTopicRepo : ITopicRepo
    {
        private NewAndNotificationContext _context;

        public SqlTopicRepo(NewAndNotificationContext context)
        {
            _context = context;
        }
        public void CreateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public void DeleteTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAllTopic()
        {
            IEnumerable<Topic> topics = _context.Topics.Include(tg => tg.tags).Include(p => p.posts).ToList();
            return topics;
        }

        public Topic GetTopicById(int id)
        {
            Topic topic = _context.Topics.Include("tags").Include("posts").ToList().FirstOrDefault(t => t.topicId == id);
            return topic;
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

    }
}
