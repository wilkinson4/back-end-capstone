using Capstone.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Friendships
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string User1Id { get; set; }

        public ApplicationUser User1 { get; set; }

        [Required]
        public string User2Id { get; set; }

        public ApplicationUser User2 { get; set; }

        [Required]
        public bool IsFriend { get; set; }
    }
}
