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

        public string Type { get; set; }

        [Required]
        public string Street { get; set; }

        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [NotMapped]
        public string FullAddress => $"{Street}, {City}, {State}, {Zip}";

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Url]
        public string WebsiteURL { get; set; }
    }
}
