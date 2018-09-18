namespace Tui.WebApplication.Tests.ServicesMock
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;
    using Tui.WebApplication.FlightClient.Interfaces;

    public class FlightApiService : IFlightApiService
    {
        private List<FlightDto> flights;

        public FlightApiService()
        {
            this.flights = new List<FlightDto>();
            this.flights.Add(new FlightDto
            {
                Id = Guid.NewGuid(),
                DepartureAirport = new AirportDto { Id = "LAX", Name = "Los Angeles International Airport (United States)" },
                DestinationAirport = new AirportDto { Id = "HND", Name = "Tokyo Haneda International Airport (Japan)" },
                Aircraft = new AircraftDto { Id = "AAA", Name = "Aircraft AAA" }
            });
        }

        async public Task Create(FlightDto flight)
        {
            this.flights.Add(flight);

            await Task.CompletedTask;
        }

        async public Task<IEnumerable<FlightDto>> GetAll()
        {
            return await Task.FromResult(this.flights.AsEnumerable());
        }

        async public Task<FlightDto> GetById(Guid id)
        {
            return await Task.FromResult(this.flights.Single(f => f.Id == id));
        }

        async public Task<IEnumerable<FlightReportDto>> GetReport()
        {
            return await Task.FromResult(this.flights.Select(f => new FlightReportDto
            {
                Id = f.Id,
                DepartureAirport = f.DepartureAirport,
                DestinationAirport = f.DestinationAirport,
                Aircraft = f.Aircraft
            }));
        }

        async public Task Update(FlightDto flight)
        {
            this.flights.Remove(this.flights.Single(f => f.Id == flight.Id));
            this.flights.Add(flight);

            await Task.CompletedTask;
        }
    }
}
