namespace Forum.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Forum.Data.Common.Repositories;
    using Forum.Data.Models;
    using Forum.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepo;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepo)
        {
            this.categoriesRepo = categoriesRepo;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            var query = this.categoriesRepo.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var category = this.categoriesRepo
                .All()
                .Where(x => x.Name == name)
                .To<T>()
                .FirstOrDefault();

            return category;
        }
    }
}
