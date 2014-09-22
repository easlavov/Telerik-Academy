namespace Forum.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Models;

    public class ArticleDetailsDataModel
    {
        public ArticleDetailsDataModel(Article article)
        {
            this.Id = article.Id;
            this.Title = article.Title;
            this.Content = article.Content;
            this.Category = article.Category.Name;
            this.DateCreated = article.DateCreated;
            this.Tags = article.Tags.Select(t => t.Name);
            this.Comments = article.Comments.AsQueryable().Select(CommentDataModel.FromComment);
            this.Likes = article.Likes.AsQueryable().Select(LikeDataModel.FromLike);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<CommentDataModel> Comments { get; set; }

        public IEnumerable<LikeDataModel> Likes { get; set; }
    }
}