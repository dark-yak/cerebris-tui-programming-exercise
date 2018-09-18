using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Flight.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tui.Flight.Domain.Models;
using Tui.Flight.Domain.Repositories;

namespace Flight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IFlightRepository flightRepository;

        public FlightsController(IFlightRepository airportRepository)
        {
            this.flightRepository = airportRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Tui.Flight.Domain.Models.Flight>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Tui.Flight.Domain.Models.Flight>> Get()
        {
            return Ok(this.flightRepository.GetAll());
        }

        [HttpGet("{id}", Name = "GetFlightById")]
        [ProducesResponseType(typeof(Tui.Flight.Domain.Models.Flight), (int)HttpStatusCode.OK)]
        public ActionResult<Tui.Flight.Domain.Models.Flight> GetFlightById(Guid id)
        {
            return Ok(this.flightRepository.GetById(id));
        }

        [HttpGet("report")]
        [ProducesResponseType(typeof(FlightReportDto), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<FlightReportDto>> GetReport()
        {
            return Ok(
                this.flightRepository.GetAll().Select(f => new FlightReportDto
                {
                    Id = f.Id,
                    DepartureAirport = f.DepartureAirport,
                    DestinationAirport = f.DestinationAirport,
                    Aircraft = f.Aircraft,
                    Distance = f.DepartureAirport.GetDistance(f.DestinationAirport),
                    FuelConsumption = f.ComputeFuelConsumption()
                }
                ));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult<Tui.Flight.Domain.Models.Flight> Create(Tui.Flight.Domain.Models.Flight flight)
        {
            this.flightRepository.Add(flight);

            return CreatedAtAction(nameof(GetFlightById), new { id = flight.Id }, null);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult<Tui.Flight.Domain.Models.Flight> Update(Tui.Flight.Domain.Models.Flight flight)
        {
            this.flightRepository.Update(flight);

            return CreatedAtAction(nameof(GetFlightById), new { id = flight.Id }, null);
        }
    }
}