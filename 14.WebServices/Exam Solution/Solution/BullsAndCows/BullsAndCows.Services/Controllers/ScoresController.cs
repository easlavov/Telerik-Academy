namespace BullsAndCows.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Services.Models;

    public class ScoresController : BaseApiController
    {
        public ScoresController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Scores()
        {
            IList<RankedUser> rankedUsers = new List<RankedUser>();
            var users = this.data.Users.All().ToList();
            foreach (var user in users)
            {
                int score = (100 * user.Wins + 15 * user.Losses);
                rankedUsers.Add(new RankedUser
                {
                    Username = user.UserName,
                    Rank = score
                });
            }

            var result = rankedUsers.AsQueryable()
                                .OrderByDescending(u => u.Rank)
                                .Take(10);

            return this.Ok(result);
        }
    }
}
