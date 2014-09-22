namespace Forum.Services.Models
{
    using Forum.Models;
    using System;
    using System.Linq.Expressions;

    public class CommentDataModel
    {
        public static Expression<Func<Comment, CommentDataModel>> FromComment
        {
            get
            {
                return c => new CommentDataModel
                {
                    ID = c.Id,
                    Content = c.Content,
                    DateCreated = c.DateCreated,
                    AuthorName = c.Author.UserName
                };
            }
        }

        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }
    }
}