using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.Core.Entities.Abstracts;
using Project.DataAccess.Mappings;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<LikedTweet> LikedTweets { get; set; }
        public DbSet<FollowedUser> FollowedUsers { get; set; }
        public DbSet<FollowingUser> FollowingUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.ApplyConfiguration(new FollowedUserMapping());
            modelBuilder.ApplyConfiguration(new FollowingUserMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new LikedTweetMapping());
            modelBuilder.ApplyConfiguration(new TweetMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                SetIfAdded(entry);
            }
        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entityEntry)
        {
            //if (entityEntry.State == EntityState.Deleted)
            //{
            //    entityEntry.Entity.DeletedDate = DateTime.Now;
            //    entityEntry.Entity.IsActive = false;
            //}
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.CreatedDate = DateTime.Now;
                entityEntry.Entity.IsActive = true;
            }
        }
    }

}

