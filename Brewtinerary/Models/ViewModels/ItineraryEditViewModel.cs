

using Capstone.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models.ViewModels
{
    public class ItineraryEditViewModel
    {
        
        public int Id { get; set; }

        public string? UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public DateTime DateOfEvent { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    }
}
