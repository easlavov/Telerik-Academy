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
    public class TagsController : BaseApiController
    {
        public TagsController(IForumData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult All(int id)
        {
            throw new NotImplementedException();
        }
    }
}
