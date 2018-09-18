namespace Tui.WebApplication.Tests.ControllersTests
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tui.WebApplication.Controllers;
    using Tui.WebApplication.FlightClient.Interfaces;
    using Tui.WebApplication.Models;
    using Tui.WebApplication.Tests.ServicesMock;
    using Xunit;
    using System;

    public class FlightsControllerTest
    {
        private IFlightApiService flightApiService;
        private IAirportApiService airportApiService;
        private IAircraftApiService aircraftApiService;

        public FlightsControllerTest()
        {
            // Could be injected
            this.flightApiService = new FlightApiService();
            this.aircraftApiService = new AircraftApiService();
            this.airportApiService = new AirportApiService();
        }

        [Fact]
        async public Task GetIndex_ReturnsFlightViewModelList()
        {
            // Arrange 
            var flightsDto = await this.flightApiService.GetAll();
            var controller = new FlightsController(this.flightApiService, this.airportApiService, this.aircraftApiService);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<FlightViewModel>>(viewResult.Model);
            Assert.Equal(flightsDto.Count(), model.Count());

            foreach(var flightDto in flightsDto)
            {
                var flightViewModel = model.Single(f => f.Id == flightDto.Id);
                Assert.Equal(flightDto.DepartureAirport.Name, flightViewModel.DepartureAirportName);
                Assert.Equal(flightDto.DestinationAirport.Name, flightViewModel.DestinationAirportName);
                Assert.Equal(flightDto.DestinationAirport.Name, flightViewModel.DestinationAirportName);
            }
        }

        [Fact]
        async public Task GetEdit_ReturnsFlightEditViewModel()
        {
            // Arrange 
            var flightDto = (await this.flightApiService.GetAll()).First();
            var controller = new FlightsController(this.flightApiService, this.airportApiService, this.aircraftApiService);

            // Act
            var result = await controller.Edit(flightDto.Id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var flightEditViewModel = Assert.IsAssignableFrom<FlightEditViewModel>(viewResult.Model);
            Assert.Equal(flightDto.DepartureAirport.Id, flightEditViewModel.DepartureAirportId);
            Assert.Equal(flightDto.DestinationAirport.Id, flightEditViewModel.DestinationAirportId);
            Assert.Equal(flightDto.Aircraft.Id, flightEditViewModel.AircraftId);
        }

        [Fact]
        async public Task GetNew_ReturnsEmptyFlightEditViewModel()
        {
            // Arrange 
            var controller = new FlightsController(this.flightApiService, this.airportApiService, this.aircraftApiService);

            // Act
            var result = await controller.New();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var flightEditViewModel = Assert.IsAssignableFrom<FlightEditViewModel>(viewResult.Model);
            Assert.Null(flightEditViewModel.DepartureAirportId);
            Assert.Null(flightEditViewModel.DestinationAirportId);
            Assert.Null(flightEditViewModel.AircraftId);
        }

        [Fact]
        async public Task PostNew_ShouldAddFlightAndRedirect()
        {
            // Arrange 
            var controller = new FlightsController(this.flightApiService, this.airportApiService, this.aircraftApiService);
            var flightEditViewModel = new FlightEditViewModel
            {
                DepartureAirportId = "SRC",
                DestinationAirportId = "DST",
                AircraftId = "AIR"
            };

            // Act
            var result = await controller.New(flightEditViewModel);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(Tui.WebApplication.Controllers.FlightsController.Index), viewResult.ActionName);

            // The new flight is in the repository ?
            var newFlight = (await this.flightApiService.GetAll()).SingleOrDefault(f =>
                f.Aircraft.Id == flightEditViewModel.AircraftId &&
                f.DepartureAirport.Id == flightEditViewModel.DepartureAirportId &&
                f.DestinationAirport.Id == flightEditViewModel.DestinationAirportId);
            
            Assert.NotNull(flightEditViewModel);
        }

        [Fact]
        async public Task PostNew_WhenInvalid_ShouldReturnBackToEdit()
        {
            // Arrange 
            var controller = new FlightsController(this.flightApiService, this.airportApiService, this.aircraftApiService);
            var flightEditViewModel = new FlightEditViewModel
            {
                DepartureAirportId = "SRC",
                DestinationAirportId = "DST",
                AircraftId = null // Invalid data
            };
            controller.ModelState.AddModelError("AircraftId", "Can not be null");

            // Act
            var result = await controller.New(flightEditViewModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<FlightEditViewModel>(viewResult.Model); // We are back with the Edit model
        }
    }
}
