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
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IForumData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            throw new NotImplementedException();
        }

        // Gets all articles, sorted by date, from Category with ID = categorID
        [HttpGet]
        public IHttpActionResult All(int id)
        {
            throw new NotImplementedException();
        }
    }
}
