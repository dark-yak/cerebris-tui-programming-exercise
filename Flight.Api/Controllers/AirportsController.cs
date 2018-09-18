using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tui.Flight.Domain.Models;
using Tui.Flight.Domain.Repositories;

namespace Flight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private IAirportRepository airportRepository;

        public AirportsController(IAirportRepository airportRepository)
        {
            this.airportRepository = airportRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Airport>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Airport>> Get()
        {
            return Ok(this.airportRepository.GetAll());
        }
    }
}