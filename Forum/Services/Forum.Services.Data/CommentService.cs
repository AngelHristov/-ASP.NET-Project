namespace Forum.Services.Data
{
    using System.Threading.Tasks;
    using Forum.Data.Common.Repositories;
    using Forum.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepo;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepo)
        {
            this.commentsRepo = commentsRepo;
        }

        public async Task Create(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                PostId = postId,
                UserId = userId,
            };

            await this.commentsRepo.AddAsync(comment);
            await this.commentsRepo.SaveChangesAsync();
        }
    }
}
