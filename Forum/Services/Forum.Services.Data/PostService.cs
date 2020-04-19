namespace Forum.Services.Data
{
    using System.Collections.Generic;
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

        public IEnumerable<T> GetByCategory<T>(int categoryId, int? take, int skip = 5)
        {
            var query = this.postRepository.All()
                 .OrderByDescending(x => x.CreatedOn)
                 .Where(x => x.CategoryId == categoryId)
                 .Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            return this.postRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }

        public int GetCountByCategoryId(int categoryId)
        {
            return this.postRepository.All().Count(x => x.CategoryId == categoryId);
        }
    }
}
