using Capstone.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class UserComments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
