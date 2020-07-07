using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public class SqlPostRepo : IPostRepo
    {
        private NewAndNotificationContext _context;

        public SqlPostRepo(NewAndNotificationContext context)
        {
            _context = context;
        }
        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPost()
        {
            IEnumerable<Post> posts = _context.Posts.Include(pt => pt.PostTags).ToList();
            return posts;
        }

        public Post GetPostById(int id)
        {
            Post post = _context.Posts.ToList().FirstOrDefault(p => p.postId == id);
            return post;
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
