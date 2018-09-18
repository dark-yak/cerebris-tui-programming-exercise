using System;

namespace Tui.WebApplication.FlightClient.Dto
{
    public class FlightReportDto
    {
        public Guid Id { get; set; }

        public AirportDto DepartureAirport { get; set; }

        public AirportDto DestinationAirport { get; set; }

        public AircraftDto Aircraft { get; set; }

        public Double Distance { get; set; }

        public Double FuelConsumption { get; set; }
    }
}
