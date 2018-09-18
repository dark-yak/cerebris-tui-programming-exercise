namespace Flight.Api.Tests
{
    using System.Linq;
    using Flight.Api.Controllers;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;
    using Xunit;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class FlightsControllerTests
    {
        private IFlightRepository flightRepository;

        private List<Flight> flights;

        public FlightsControllerTests()
        {
            this.flights = new List<Flight>();
            flights.Add(new Flight(
                                new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999),
                                new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971),
                                new Aircraft("OO-JAA", "VICTORY", 10, 100)
                                ));
            flights.Add(new Flight(
                                new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999),
                                new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971),
                                new Aircraft("OO-SPC", "SPACE SHUTTLE", 0, 100)
                                ));

            this.flightRepository = new global::Flight.Api.Tests.Repositories.FlightRepository(flights);
        }

        [Fact]
        public void GetAll_ShouldReturnAllFlights()
        {
            // Arrange
            FlightsController controller = new FlightsController(this.flightRepository);

            // Act
            var actionResult = controller.Get();

            // Asserts
            // Assert 1 : Call OK - 200
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            // Assert 2 : same number of flights
            var apiFlights = okResult.Value as IEnumerable<Flight>;
            Assert.Equal(this.flights.Count, apiFlights.Count());

            // Assert 3 : find each flight
            foreach (var flight in flights)
            {
                var apiFlight = apiFlights.Single(a => a.Id == flight.Id);
                Assert.Equal(flight.Aircraft.Name, apiFlight.Aircraft.Name);
                Assert.Equal(flight.DepartureAirport.Name, apiFlight.DepartureAirport.Name);
                Assert.Equal(flight.DestinationAirport.Name, apiFlight.DestinationAirport.Name);
            }
        }

        [Fact]
        public void GetFlightById_ShouldReturnOneMatchingFlight()
        {
            // Arrange
            FlightsController controller = new FlightsController(this.flightRepository);
            Flight flightToRetrieve = this.flightRepository.GetAll().First();

            // Act
            var actionResult = controller.GetFlightById(flightToRetrieve.Id);

            // Asserts
            // Assert 1 : Call OK - 200
            Assert.IsType<OkObjectResult>(actionResult.Result);

            // Assert 2 : check the flight
            var apiFlight = (actionResult.Result as OkObjectResult).Value as Flight;
            Assert.Equal(flightToRetrieve.Aircraft.Name, apiFlight.Aircraft.Name);
            Assert.Equal(flightToRetrieve.DepartureAirport.Name, apiFlight.DepartureAirport.Name);
            Assert.Equal(flightToRetrieve.DestinationAirport.Name, apiFlight.DestinationAirport.Name);
        }

        [Fact]
        public void Create_ShouldAddFlight()
        {
            // Arrange
            var flightToAdd = new Flight(
                                new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999),
                                new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971),
                                new Aircraft("OO-JAA", "VICTORY", 0, 0)
                                );
            FlightsController controller = new FlightsController(this.flightRepository);

            // Act
            var actionResult = controller.Create(flightToAdd);

            // Asserts
            // Assert 1 : Call OK - 200
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            // retrieve the new flight in the repository
            var newFlightIdFromApi = (Guid)(actionResult.Result as CreatedAtActionResult).RouteValues["id"];
            var flightFromRepository = this.flightRepository.GetById(newFlightIdFromApi);

            // Assert 2 : check created flight match the new one
            Assert.Equal(flightToAdd.Aircraft.Name, flightFromRepository.Aircraft.Name);
            Assert.Equal(flightToAdd.DepartureAirport.Name, flightFromRepository.DepartureAirport.Name);
            Assert.Equal(flightToAdd.DestinationAirport.Name, flightFromRepository.DestinationAirport.Name);
        }

        [Fact]
        public void Update_ShouldModifyFlight()
        {
            // Arrange
            FlightsController controller = new FlightsController(this.flightRepository);
            Guid modifiedFlightId = this.flightRepository.GetAll().First().Id;
            
            // Create a completely new flight
            Flight modifiedFlight = new Flight(
                new Airport("MODIF1", "Modified DepartureAirport", 33.94250107, -118.4079971),
                new Airport("MODIF2", "Modified DestinationAirport", 33.94250107, -118.4079971),
                new Aircraft("MODIF3", "Modified Aircraft", 33.94250107, -118.4079971)
            );
            modifiedFlight.Id = modifiedFlightId; // Keep the id of the flight

            // Act
            var actionResult = controller.Update(modifiedFlight);

            // Asserts
            // Assert 1 : Call OK - 200
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            // retrieve the new flight in the repository
            var flightFromRepository = this.flightRepository.GetById(modifiedFlight.Id);

            // Assert 2 : check created flight match the new one
            Assert.Equal(modifiedFlight.Aircraft.Name, flightFromRepository.Aircraft.Name);
            Assert.Equal(modifiedFlight.DepartureAirport.Name, flightFromRepository.DepartureAirport.Name);
            Assert.Equal(modifiedFlight.DestinationAirport.Name, flightFromRepository.DestinationAirport.Name);
        }
    }
}