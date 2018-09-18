namespace Flight.Api.Tests
{
    using System.Linq;
    using Flight.Api.Controllers;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;
    using Xunit;
    using Microsoft.AspNetCore.Mvc;

    public class AircraftsControllerTests
    {
        private IAircraftRepository aircraftRepository;

        private List<Aircraft> aircrafts;

        public AircraftsControllerTests()
        {
            this.aircrafts = new List<Aircraft>();
            aircrafts.Add(new Aircraft("AAA", "Aircraft AAA", 1, 0));
            aircrafts.Add(new Aircraft("BBB", "Aircraft BBB", 10, 1));

            this.aircraftRepository = new global::Flight.Api.Tests.Repositories.AircraftRepository(aircrafts);
        }

        [Fact]
        public void GetAll_ShouldReturnAllAircrafts()
        {
            // Arrange
            AircraftsController controller = new AircraftsController(this.aircraftRepository);

            // Act
            var actionResult = controller.Get();

            // Asserts
            // Assert 1 : Call OK - 200
            Assert.IsType<OkObjectResult>(actionResult.Result);

            // Assert 2 : same number of aircrafts
            var apiAircrafts = (actionResult.Result as OkObjectResult).Value as IEnumerable<Aircraft>;
            Assert.Equal(this.aircrafts.Count, apiAircrafts.Count());

            // Assert 3 : find each aircraft
            foreach (var aircraft in aircrafts)
            {
                Assert.Equal(aircraft.Name, apiAircrafts.Single(a => a.Id == aircraft.Id).Name);
            }
        }
    }
}