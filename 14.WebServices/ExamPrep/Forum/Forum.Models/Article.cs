namespace Forum.Models
{
    using System;
    using System.Collections.Generic;

    public class Article
    {

        private ICollection<Comment> comments;   
        private ICollection<Like> likes;
        private ICollection<Tag> tags;

        public Article()
        {
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
            this.tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}
