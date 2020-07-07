using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public interface IPostTagsRepo
    {
        bool SaveChange();
        IEnumerable<PostTags> GetAllPostTags();
        Post GetPostTagsById(int id);
        void CreatePostTags(PostTags post);
        void UpdatePostTags(PostTags post);
        void DeletePostTags(PostTags post);
    }
}
