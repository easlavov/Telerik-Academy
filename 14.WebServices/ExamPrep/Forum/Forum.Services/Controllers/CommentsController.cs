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
    public class CommentsController : BaseApiController
    {
        public CommentsController(IForumData data)
            : base(data)
        {
        }

        //Creates a new comment for a given article
        [HttpPost]
        public IHttpActionResult Create(int articleId, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
