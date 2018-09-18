namespace Flight.Api.Tests
{
    using System.Linq;
    using Flight.Api.Controllers;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;
    using Xunit;
    using Microsoft.AspNetCore.Mvc;

    public class AirportsControllerTests
    {
        private IAirportRepository airportRepository;

        private List<Airport> airports;

        public AirportsControllerTests()
        {
            this.airports = new List<Airport>();
            airports.Add(new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971));
            airports.Add(new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999));

            this.airportRepository = new global::Flight.Api.Tests.Repositories.AirportRepository(airports);
        }

        [Fact]
        public void GetAll_ShouldReturnAllAirports()
        {
            // Arrange
            AirportsController controller = new AirportsController(this.airportRepository);

            // Act
            var actionResult = controller.Get();

            // Asserts
            // Assert 1 : Call OK - 200
            Assert.IsType<OkObjectResult>(actionResult.Result);

            // Assert 2 : same number of airports
            var apiAirports = (actionResult.Result as OkObjectResult).Value as IEnumerable<Airport>;
            Assert.Equal(this.airports.Count, apiAirports.Count());

            // Assert 3 : find each airport
            foreach (var airport in airports)
            {
                Assert.Equal(airport.Name, apiAirports.Single(a => a.Id == airport.Id).Name);
            }
        }
    }
}