namespace Flight.Api.Tests.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;

    public class FlightRepository : IFlightRepository
    {
        private List<Flight> flights;

        public FlightRepository(List<Flight> flights) 
        {
            this.flights = flights;
        }

        public void Add(Flight flight)
        {
            this.flights.Add(flight);
        }

        public IEnumerable<Flight> GetAll()
        {
            return flights;
        }

        public Flight GetById(Guid flightId)
        {
            return this.GetAll().FirstOrDefault(a => a.Id == flightId);
        }

        public void Update(Flight flight)
        {
            this.flights.Remove(this.flights.Single(f => f.Id == flight.Id));
            this.flights.Add(flight);
        }
    }
}
