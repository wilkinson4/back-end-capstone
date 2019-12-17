using Capstone.Models.ViewModels;
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
        
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfEvent { get; set; }

        [NotMapped]
        public string ShortDate => DateOfEvent.ToString("d");

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public virtual ICollection<ItineraryBrewery> ItineraryBreweries { get; set; }

        public List<ItineraryBreweryViewModel> ItineraryBreweryViewModels { get; set; }
    }
}
