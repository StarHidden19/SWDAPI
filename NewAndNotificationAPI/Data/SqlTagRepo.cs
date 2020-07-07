using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public class SqlTagRepo : ITagRepo
    {
        private NewAndNotificationContext _context;

        public SqlTagRepo(NewAndNotificationContext context)
        {
            _context = context;
        }
        public void CreateTag(Tag topic)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(Tag topic)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAllTag()
        {
            IEnumerable<Tag> tags = _context.Tags.Include(tg=>tg.PostTags).ThenInclude(p=>p.post).ToList();
            return tags;

            
        }

        public Tag GetTagById(int id)
        {
            Tag tag = _context.Tags.Include(tg => tg.PostTags).ThenInclude(p => p.post).FirstOrDefault(t => t.tagId == id);
            return tag;
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdateTag(Tag topic)
        {
            throw new NotImplementedException();
        }
    }
}
