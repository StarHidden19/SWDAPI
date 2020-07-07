using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Models;

namespace NewAndNotificationAPI.Data
{
    public class NewAndNotificationContext : DbContext
    {
        public NewAndNotificationContext(DbContextOptions<NewAndNotificationContext> options)
            :base(options)
        {

        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentTags> StudentTags { get; set; }
        public DbSet<StudentTopics> StudentTopics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Topic - Tag
            modelBuilder.Entity<Tag>()
            .HasOne<Topic>(tg => tg.topic)
            .WithMany(t => t.tags);

            //Post - Topic 
            modelBuilder.Entity<Post>()
           .HasOne<Topic>(p => p.topic)
           .WithMany(t => t.posts);

           
            // Tag - TagPost 
            modelBuilder.Entity<PostTags>()
           .HasOne<Tag>(pt => pt.tag)
           .WithMany(t => t.PostTags)
           .OnDelete(DeleteBehavior.NoAction); 
            // Post - TagPost 
            modelBuilder.Entity<PostTags>()
           .HasOne<Post>(pt => pt.post)
           .WithMany(p => p.PostTags)
           .OnDelete(DeleteBehavior.NoAction);

            //Student - StudentTopic
            modelBuilder.Entity<StudentTopics>()
          .HasOne<Student>(st => st.student)
          .WithMany(s => s.StudentTopics)
          .OnDelete(DeleteBehavior.NoAction);
            //Topic - StudenTopic
            modelBuilder.Entity<StudentTopics>()
          .HasOne<Topic>(st => st.topic)
          .WithMany(t => t.StudentTopics)
          .OnDelete(DeleteBehavior.NoAction);

            //Tag -StudentTag
            modelBuilder.Entity<StudentTags>()
         .HasOne<Tag>(st => st.tag)
         .WithMany(t => t.StudentTags)
         .OnDelete(DeleteBehavior.NoAction);
            //Student -StudentTag
            modelBuilder.Entity<StudentTags>()
         .HasOne<Student>(st => st.student)
         .WithMany(s => s.StudentTags)
         .OnDelete(DeleteBehavior.NoAction);
        }




    }
}
