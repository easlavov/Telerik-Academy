namespace Forum.Models
{
    using System;

    public class Like
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
