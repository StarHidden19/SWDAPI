using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public interface IPostRepo
    {
        bool SaveChange();
        IEnumerable<Post> GetAllPost();
        Post GetPostById(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
