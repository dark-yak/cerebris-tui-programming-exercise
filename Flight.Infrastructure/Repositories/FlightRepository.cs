namespace Tui.Flight.Infrastructure.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;
    using Tui.Flight.Infrastructure.Models;

    public class FlightRepository : IFlightRepository
    {        
        private XmlRepositoryHelper<PersistenceFlight> xmlHelper;

        private IAircraftRepository aircraftRepository;
        private IAirportRepository airportRepository;

        public FlightRepository(IAircraftRepository aircraftRepository, IAirportRepository airportRepository)
        {
            this.xmlHelper = new XmlRepositoryHelper<PersistenceFlight>(@"SampleData\Flights.xml");
            this.aircraftRepository = aircraftRepository;
            this.airportRepository = airportRepository;
        }

        public IEnumerable<Flight> GetAll()
        {
            return this.xmlHelper.GetAll().Select(pf => new Flight
            {
                Id = pf.Id,
                DepartureAirport = this.airportRepository.GetById(pf.DepartureAirportId),
                DestinationAirport = this.airportRepository.GetById(pf.DestinationAirportId),
                Aircraft = this.aircraftRepository.GetById(pf.AircraftId)
            });
        }

        public Flight GetById(Guid flightId)
        {
            return this.GetAll().FirstOrDefault(f => f.Id == flightId);
        }

        public void Add(Flight flight)
        {
            // Id generation is the responsibility of the repository
            flight.Id = Guid.NewGuid();

            var allFlights = this.xmlHelper.GetAll();
            allFlights.Add(new PersistenceFlight(flight));

            this.xmlHelper.SaveAll(allFlights);
        }

        public void Update(Flight flight)
        {
            var allFlights = this.xmlHelper.GetAll();

            var existingFlight = allFlights.SingleOrDefault(f => f.Id == flight.Id);

            if (existingFlight == null)
                throw new ArgumentException("The flight does not exist in the datastore");

            // Remplace the previous instance
            allFlights.Remove(existingFlight);
            allFlights.Add(new PersistenceFlight(flight));

            this.xmlHelper.SaveAll(allFlights);
        }
    }
}
