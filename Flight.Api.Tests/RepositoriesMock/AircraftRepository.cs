namespace Flight.Api.Tests.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;

    public class AirportRepository : IAirportRepository
    {
        private IEnumerable<Airport> airports;

        public AirportRepository(IEnumerable<Airport> airports) 
        {
            this.airports = airports;
        }

        public IEnumerable<Airport> GetAll()
        {
            return airports;
        }

        public Airport GetById(String airportId)
        {
            return this.GetAll().FirstOrDefault(a => a.Id == airportId);
        }
    }
}
