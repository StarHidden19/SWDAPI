using AutoMapper;
using NewAndNotificationAPI.Dtos;
using NewAndNotificationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAndNotificationAPI.Profiles
{
    public class NewAndNotificationProfile : Profile
    {
        public NewAndNotificationProfile()
        {
            CreateMap<StudentTags, StudentTagReadDto>();
            CreateMap<Post, PostReadDto>();
            CreateMap<PostTags, PostTagsReadDto>();
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentTags, StudentTagReadDto>();
            CreateMap<StudentTopics, StudentTopicReadDto>();
            CreateMap<Tag, TagReadDto>();
            CreateMap<Topic, TopicReadDto>();
        }
    }
    
}
