namespace Tui.WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Tui.WebApplication.FlightClient.Interfaces;
    using Tui.WebApplication.Models;

    public class AircraftsController : Controller
    {
        private IAircraftApiService aircraftApiService;

        public AircraftsController(IAircraftApiService aircraftApiService)
        {
            this.aircraftApiService = aircraftApiService;
        }

        async public Task<IActionResult> Index()
        {
            var aircraftsDto = await aircraftApiService.GetAll();

            var aircraftsViewModel = aircraftsDto.Select(aircraftDto => new AircraftViewModel(aircraftDto));

            return View(aircraftsViewModel);
        }
    }
}