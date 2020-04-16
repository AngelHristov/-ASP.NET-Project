namespace Forum.Web.ViewModels.Categories
{
    using System;

    using Forum.Data.Models;
    using Forum.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string UserUserName { get; set; }

        public int ComentsCount { get; set; }

        public string Content { get; set; }

        public string ShortContent =>
            this.Content?.Length > 100 ? this.Content?.Substring(0, 50) + "..."
            : this.Content;
    }
}
