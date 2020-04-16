namespace Forum.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count);

        T GetByName<T>(string name);
    }
}
