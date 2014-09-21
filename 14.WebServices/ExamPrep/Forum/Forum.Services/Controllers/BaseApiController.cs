namespace Forum.Services.Controllers
{
    using System.Web.Http;

    using Forum.Data;

    public class BaseApiController : ApiController
    {
        protected IForumData data;

        public BaseApiController(IForumData data)
        {
            this.data = data;
        }
    }
}
