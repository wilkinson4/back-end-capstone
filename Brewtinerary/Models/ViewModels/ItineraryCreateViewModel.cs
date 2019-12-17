using System;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models.ViewModels
{
    public class ItineraryCreateViewModel
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfEvent { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
