using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Capstone.Models.Data
{
    public class Brewery
    {
        [Key]
        public int Id { get; set; }

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

        [NotMapped]
        public string FullAddress => $"{Street}, {City}, {State}, {Postal_Code}";

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Url]
        public string Website_URL { get; set; }

        public ICollection<Beer> Beers { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
