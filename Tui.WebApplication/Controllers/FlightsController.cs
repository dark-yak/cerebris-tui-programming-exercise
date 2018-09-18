namespace Tui.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Options;
    using Tui.WebApplication.FlightClient.Dto;
    using Tui.WebApplication.FlightClient.Interfaces;
    using Tui.WebApplication.Models;

    public class FlightsController : Controller
    {
        private IFlightApiService flightApiService;
        private IAirportApiService airportApiService;
        private IAircraftApiService aircraftApiService;

        public FlightsController(IFlightApiService flightApiService, IAirportApiService airportApiService, IAircraftApiService aircraftApiService)
        {
            this.flightApiService = flightApiService;
            this.airportApiService = airportApiService;
            this.aircraftApiService = aircraftApiService;
        }

        async Task PopulateLists(FlightEditViewModel flightEditViewModel)
        {
            var airportsDto = await airportApiService.GetAll();
            var aircraftsDto = await aircraftApiService.GetAll();

            flightEditViewModel.Airports = new SelectList(airportsDto.OrderBy(a => a.Name), "Id", "Name");
            flightEditViewModel.Aircrafts = new SelectList(aircraftsDto.OrderBy(a => a.Name), "Id", "Name");
        }

        async public Task<IActionResult> Index()
        {
            var flightDto = await flightApiService.GetAll();
        
            var flightViewModel = flightDto.Select(f => new FlightViewModel
            {
                Id = f.Id,
                DepartureAirportName = f.DepartureAirport.Name,
                DestinationAirportName = f.DestinationAirport.Name,
                AircraftName = f.Aircraft.Name
            }).OrderBy(f => f.AircraftName);

            return View(flightViewModel);
        }

        async public Task<IActionResult> Report()
        {
            var flightReport = (await flightApiService.GetReport()).OrderBy(f => f.Aircraft.Name);

            return View(flightReport);
        }

        async public Task<IActionResult> Edit(Guid id)
        {            
            var flightDto = await flightApiService.GetById(id);

            var flightEditViewModel = new FlightEditViewModel
            {
                Id = flightDto.Id,
                DepartureAirportId = flightDto.DepartureAirport.Id,
                DestinationAirportId = flightDto.DestinationAirport.Id,
                AircraftId = flightDto.Aircraft.Id                                
            };

            await this.PopulateLists(flightEditViewModel);

            return View(flightEditViewModel);
        }

        [HttpPost]
        async public Task<IActionResult> Edit(FlightEditViewModel flightEditViewModel)
        {
            this.EnforceCustomValidation(flightEditViewModel);

            if (this.ModelState.IsValid)
            {
                var flightDto = new FlightDto
                {
                    Id = flightEditViewModel.Id,
                    DepartureAirport = new AirportDto { Id = flightEditViewModel.DepartureAirportId },
                    DestinationAirport = new AirportDto { Id = flightEditViewModel.DestinationAirportId },
                    Aircraft = new AircraftDto { Id = flightEditViewModel.AircraftId }
                };

                await this.flightApiService.Update(flightDto);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                await this.PopulateLists(flightEditViewModel);

                return View(flightEditViewModel);
            }
        }

        async public Task<IActionResult> New()
        {
            var flightViewModel = new FlightEditViewModel();

            await this.PopulateLists(flightViewModel);

            return View(flightViewModel);
        }

        [HttpPost]
        async public Task<IActionResult> New(FlightEditViewModel flightEditViewModel)
        {
            this.EnforceCustomValidation(flightEditViewModel);

            if (this.ModelState.IsValid)
            {
                var flightDto = new FlightDto
                {
                    DepartureAirport = new AirportDto { Id = flightEditViewModel.DepartureAirportId },
                    DestinationAirport = new AirportDto { Id = flightEditViewModel.DestinationAirportId },
                    Aircraft = new AircraftDto { Id = flightEditViewModel.AircraftId }
                };

                await this.flightApiService.Create(flightDto);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                await this.PopulateLists(flightEditViewModel);

                return View(flightEditViewModel);
            }
        }

        private void EnforceCustomValidation(FlightEditViewModel flightEditViewModel)
        {
            if (flightEditViewModel.DepartureAirportId == flightEditViewModel.DestinationAirportId)
            {
                this.ModelState.AddModelError("DepartureAirportId", "The departure and destination airports must differ");
                this.ModelState.AddModelError("DestinationAirportId", "The departure and destination airports must differ");
            }
        }
    }
}