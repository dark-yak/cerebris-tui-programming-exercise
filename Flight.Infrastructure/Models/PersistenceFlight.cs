namespace Tui.Flight.Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tui.Flight.Domain.Models;

    /// <summary>
    /// Represent the flight in the persistence storage (no navigation entity)
    /// </summary>
    public class PersistenceFlight
    {
        public PersistenceFlight()
        {

        }

        public PersistenceFlight(Flight flight)
        {
            this.Id = flight.Id;
            this.DepartureAirportId = flight.DepartureAirport.Id;
            this.DestinationAirportId = flight.DestinationAirport.Id;
            this.AircraftId = flight.Aircraft.Id;
        }

        public Guid Id { get; set; }

        public String DepartureAirportId { get; set; }

        public String DestinationAirportId { get; set; }

        public String AircraftId { get; set; }
    }
}
