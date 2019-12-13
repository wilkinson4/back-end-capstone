using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels
{
    public class BreweryCreateViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public string Brewery_Type { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Postal_Code { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Url]
        public string Website_URL { get; set; }
    }
}
