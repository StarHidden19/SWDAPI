using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public class SqlPostTagsRepo : IPostTagsRepo
    {
        private NewAndNotificationContext _context;

        public SqlPostTagsRepo(NewAndNotificationContext context)
        {
            _context = context;
        }
        public void CreatePostTags(PostTags post)
        {
            throw new NotImplementedException();
        }

        public void DeletePostTags(PostTags post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostTags> GetAllPostTags()
        {
            IEnumerable<PostTags> tags = _context.PostTags.ToList();
            return tags;
        }

        public Post GetPostTagsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdatePostTags(PostTags post)
        {
            throw new NotImplementedException();
        }
    }
}
