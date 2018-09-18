namespace Tui.WebApplication.FlightClient.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FlightDto
    {
        public Guid Id { get; set; }

        public AirportDto DepartureAirport { get; set; }

        public AirportDto DestinationAirport { get; set; }

        public AircraftDto Aircraft { get; set; }

    }
}
