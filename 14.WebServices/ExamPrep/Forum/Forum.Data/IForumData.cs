using Forum.Data.Repositories;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public interface IForumData
    {
        IRepository<Article> Articles { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Like> Likes { get; }

        IRepository<Tag> Tags { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}
