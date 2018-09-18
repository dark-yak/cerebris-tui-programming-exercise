namespace Tui.WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FlightViewModel
    {
        public Guid Id { get; set; }

        public String DepartureAirportName { get; set; }

        public String DestinationAirportName { get; set; }

        public String AircraftName { get; set; }
    }
}
