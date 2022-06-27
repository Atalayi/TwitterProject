using Microsoft.Extensions.DependencyInjection;
using Project.Business.Concretes;
using Project.Business.Interfaces;
using Project.DataAccess.Concretes;
using Project.DataAccess.Interfaces;

namespace Project.UI.Extensions
{
    public static class ConfigurationCollection
    {
        public static void Transients(this IServiceCollection services)
        {
            services.AddTransient<IFollowedUserRepository, FollowedUserRepository>();
            services.AddTransient<IFollowingUsersRepository, FollowingUserRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ITweetRepository, TweetRepository>();
            services.AddTransient<ILikedTweetRepository, LikedTweetRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IFollowedUserService, FollowedUserService>();
            services.AddTransient<IFollowingUserService, FollowingUserService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ITweetService, TweetService>();
            services.AddTransient<ILikedTweetService, LikedTweetService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
