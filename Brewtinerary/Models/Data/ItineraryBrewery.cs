using System.ComponentModel.DataAnnotations;

namespace Capstone.Models.Data
{
    public class ItineraryBrewery
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ItineraryId { get; set; }

        public Itinerary Itinerary { get; set; }

        [Required]
        public int BreweryId { get; set; }
    }
}
