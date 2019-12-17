using System;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models.ViewModels
{
    public class ItineraryCreateViewModel
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public string DateOfEvent { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
