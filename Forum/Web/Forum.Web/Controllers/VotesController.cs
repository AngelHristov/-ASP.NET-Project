namespace Forum.Web.Controllers
{
    using System.Threading.Tasks;

    using Forum.Data.Models;
    using Forum.Services.Data;
    using Forum.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVoteService votesService, UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.votesService.VoteAsync(input.PostId, user.Id, input.IsUpVote);
            var votes = this.votesService.GetVotes(input.PostId);
            return new VoteResponseModel { votesCount = votes };
        }
    }
}
