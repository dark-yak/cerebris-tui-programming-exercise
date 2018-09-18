namespace Tui.WebApplication.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class FlightEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Departure airport")]
        public String DepartureAirportId { get; set; }

        [Required]
        [Display(Name = "Destination airport")]
        public String DestinationAirportId { get; set; }

        [Required]
        [Display(Name = "Aircraft")]
        public String AircraftId { get; set; }

        public IEnumerable<SelectListItem> Aircrafts { get; set; }

        public IEnumerable<SelectListItem> Airports{ get; set; }
    }
}
