using System.ComponentModel.DataAnnotations;
using Forum.Data.Common.Models;

namespace Forum.Data.Models
{
    public class Vote : BaseModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }

    }
}
