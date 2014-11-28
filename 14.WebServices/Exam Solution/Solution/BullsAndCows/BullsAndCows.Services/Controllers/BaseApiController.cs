namespace BullsAndCows.Services.Controllers
{
    using System.Web.Http;

    using BullsAndCows.Data;

    public class BaseApiController : ApiController
    {
        protected IBullsAndCowsData data;

        public BaseApiController(IBullsAndCowsData data)
        {
            this.data = data;
        }
    }
}
