using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tui.Flight.Domain.Models;

namespace Flight.Api.Models
{
    public class FlightReportDto
    {
        public Guid Id { get; set; }

        public Airport DepartureAirport { get; set; }

        public Airport DestinationAirport { get; set; }

        public Aircraft Aircraft { get; set; }

        public Double Distance { get; set; }

        public Double FuelConsumption { get; set; }
    }
}
