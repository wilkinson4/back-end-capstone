using System.ComponentModel.DataAnnotations;

namespace Capstone.Models.Data
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BreweryId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
