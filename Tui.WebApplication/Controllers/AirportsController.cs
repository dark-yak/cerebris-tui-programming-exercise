namespace Tui.WebApplication.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Tui.WebApplication.FlightClient.Interfaces;
    using Tui.WebApplication.Models;

    public class AirportsController : Controller
    {
        private IAirportApiService airportApiService;

        public AirportsController(IAirportApiService airportApiService)
        {
            this.airportApiService = airportApiService;
        }

        async public Task<IActionResult> Index()
        {
            var airportsDto = await airportApiService.GetAll();

            var airportsViewModel = airportsDto.Select(airportDto => new AirportViewModel(airportDto));

            return View(airportsViewModel);
        }
    }
}