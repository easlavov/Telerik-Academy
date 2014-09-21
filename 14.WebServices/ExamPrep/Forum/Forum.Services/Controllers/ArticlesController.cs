namespace Forum.Services.Controllers
{
    using Forum.Data;
    using Forum.Models;
    using Forum.Services.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    public class ArticlesController : BaseApiController
    {
        private const int ITEMS_PER_PAGE = 10;

        public ArticlesController(IForumData data)
            : base(data)
        {
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(ArticleDataModel model)
        {
            var userId = this.User.Identity.GetUserId();

            var category = GetCategory(model);
            var tags = GetTags(model);

            var article = new Article()
            {
                Title = model.Title,
                AuthorId = userId,
                Content = model.Content,
                CategoryId = category.Id,
                DateCreated = DateTime.Now,
                Tags = tags
            };

            this.data.Articles.Add(article);
            this.data.SaveChanges();

            model.Id = article.Id;
            model.DateCreated = article.DateCreated;
            model.Tags = article.Tags.Select(t => t.Name);

            return this.Ok(model);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(null, 0);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            return this.All(null, page);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult All(string category)
        {
            return this.All(category, 0);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult All(string category, int page)
        {
            var articles = AllArticlesByDate()
                .Where(a => category != null ? a.Category.Name == category : true)
                    .Skip(ITEMS_PER_PAGE * page)
                    .Take(ITEMS_PER_PAGE)
                    .Select(ArticleDataModel.FromArticle)
                    .ToList();

            return this.Ok(articles);
        }

        private IQueryable<Article> AllArticlesByDate()
        {
            return this.data.Articles.All().OrderBy(a => a.DateCreated);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return this.NotFound();
            }

            var model = new ArticleDetailsDataModel(article);
            return this.Ok(model);
        }

        private ICollection<Tag> GetTags(ArticleDataModel model)
        {
            var tags = new HashSet<Tag>();

            var newTags = model.Tags.ToList();
            var tagsFromTitle = model.Title.Split(' ').ToList();
            newTags.AddRange(tagsFromTitle);
            foreach (var newTag in newTags)
            {
                var tag = this.data.Tags.All().FirstOrDefault(t => t.Name == newTag);
                if (tag == null)
                {
                    tag = new Tag();
                    tag.Name = newTag;
                    this.data.Tags.Add(tag);
                }

                tags.Add(tag);
            }

            return tags;
        }

        private Category GetCategory(ArticleDataModel model)
        {
            string name = model.Category;
            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == name);
            if (category == null)
            {
                category = new Category();
                category.Name = name;
                this.data.Categories.Add(category);
            }

            return category;
        }
    }
}
