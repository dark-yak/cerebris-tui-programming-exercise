namespace Tui.Flight.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;

    public class AirportRepository : IAirportRepository
    {
        private XmlRepositoryHelper<Airport> xmlHelper;

        public AirportRepository()
        {
            this.xmlHelper = new XmlRepositoryHelper<Airport>(@"SampleData\Airports.xml");
        }

        public IEnumerable<Airport> GetAll()
        {
            return this.xmlHelper.GetAll();
        }

        public Airport GetById(String airportId)
        {
            return this.GetAll().FirstOrDefault(a => a.Id == airportId);
        }
    }
}
