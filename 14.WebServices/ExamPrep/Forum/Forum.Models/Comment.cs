﻿namespace Forum.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
