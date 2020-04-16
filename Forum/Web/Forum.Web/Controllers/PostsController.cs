namespace Forum.Web.Controllers
{
    using System.Threading.Tasks;

    using Forum.Data.Common.Repositories;
    using Forum.Data.Models;
    using Forum.Services.Data;
    using Forum.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        private readonly IPostService postService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(
            IPostService postService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.postService = postService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>(null);

            var viewModel = new PostCreateInputModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postId = await this.postService.CreateAsync(
                input.Title,
                input.Content,
                input.CategoryId,
                user.Id);

            return this.RedirectToAction(nameof(this.ById), new { id = postId }); // new { id = postId}
        }
    }
}
