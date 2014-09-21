namespace Forum.Services.Controllers
{
    using Forum.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [Authorize]
    public class LikesController : BaseApiController
    {
        public LikesController(IForumData data)
            : base(data)
        {            
        }

        [HttpPost]
        public IHttpActionResult Create(int articleId)
        {
            return this.Ok();
        }

        // Removes a like by the current user for the article with ID = articleID
        [HttpPut]
        public IHttpActionResult Remove(int articleId)
        {
            return this.Ok();
        }
    }
}
