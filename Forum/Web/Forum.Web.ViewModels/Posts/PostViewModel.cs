namespace Forum.Web.ViewModels.Posts
{
    using System;

    using Forum.Data.Models;
    using Forum.Services.Mapping;
    using Ganss.XSS;

    public class PostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
