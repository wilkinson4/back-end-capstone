using Capstone.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int ItineraryId { get; set; }

        public Itinerary Itinerary { get; set; }
    }
}
