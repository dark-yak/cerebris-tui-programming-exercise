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
    public class AircraftsController : ControllerBase
    {
        private IAircraftRepository aircraftRepository;

        public AircraftsController(IAircraftRepository aircraftRepository)
        {
            this.aircraftRepository = aircraftRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Aircraft>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Aircraft>> Get()
        {
            return Ok(this.aircraftRepository.GetAll());
        }
    }
}