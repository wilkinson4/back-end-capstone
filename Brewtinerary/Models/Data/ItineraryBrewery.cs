using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Brewery Brewery { get; set; }
    }
}
