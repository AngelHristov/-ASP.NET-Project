namespace Forum.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Forum.Data.Common.Repositories;
    using Forum.Data.Models;
    using Forum.Services.Mapping;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                CategoryId = categoryId,
                Content = content,
                Title = title,
                UserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();

            return post.Id;
        }

        public T GetById<T>(int id)
        {
            return this.postRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }
    }
}
