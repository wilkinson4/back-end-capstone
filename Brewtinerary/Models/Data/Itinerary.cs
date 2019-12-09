using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models.Data
{
    public class Itinerary
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [NotMapped]
        public ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfEvent { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<ItineraryBrewery> ItineraryBreweries { get; set; }
    }
}
