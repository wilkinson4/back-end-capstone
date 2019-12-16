
using Capstone.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models.ViewModels
{
    public class ItineraryBreweryViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ItineraryId { get; set; }

        public int BreweryId { get; set; }

        public Brewery Brewery { get; set; }

    }
}
