﻿namespace Forum.Web.ViewModels.Comments
{
    public class CreateCommentInputModel
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        public int ParentId { get; set; }
    }
}
