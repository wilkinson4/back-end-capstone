using Capstone.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class SharedItinerary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        [Required]
        public string OtherUserId { get; set; }

        public ApplicationUser OtherUser { get; set; }

        [Required]
        public int ItineraryId { get; set; }

        public Itinerary Itinerary { get; set; }
    }
}
