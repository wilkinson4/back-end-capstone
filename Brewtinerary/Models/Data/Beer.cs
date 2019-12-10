using System.ComponentModel.DataAnnotations;

namespace Capstone.Models.Data
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double ABV { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public int BreweryId { get; set; }

        public Brewery Brewery { get; set; }
    }
}
