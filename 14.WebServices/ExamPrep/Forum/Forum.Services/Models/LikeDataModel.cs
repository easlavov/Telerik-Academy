namespace Forum.Services.Models
{
    using Forum.Models;
    using System;
    using System.Linq.Expressions;

    public class LikeDataModel
    {
        public static Expression<Func<Like, LikeDataModel>> FromLike
        {
            get
            {
                return like => new LikeDataModel
                {
                    ID = like.Id,
                    DateCreated = like.DateCreated,
                    AuthorName = like.Author.UserName
                };
            }
        }

        public int ID { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}