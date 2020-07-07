using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Data
{
    public interface ITagRepo
    {
        bool SaveChange();
        IEnumerable<Tag> GetAllTag();
        Tag GetTagById(int id);
        void CreateTag(Tag topic);
        void UpdateTag(Tag topic);
        void DeleteTag(Tag topic);
    }
}
