namespace Forum.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostService
    {
        Task<int> CreateAsync(string title, string content, int categoryId, string userId);

        T GetById<T>(int id);

        IEnumerable<T> GetByCategory<T>(int categoryId, int? take, int skip = 5);

        int GetCountByCategoryId(int categoryId);
    }
}
