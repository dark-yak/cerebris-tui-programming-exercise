namespace Tui.WebApplication.Tests.ServicesMock
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;
    using Tui.WebApplication.FlightClient.Interfaces;

    public class AircraftApiService : IAircraftApiService
    {
        private List<AircraftDto> aircrafts;

        public AircraftApiService()
        {
            this.aircrafts = new List<AircraftDto>();
            this.aircrafts.Add(new AircraftDto { Id = "AAA", Name = "Aircraft AAA" });
            this.aircrafts.Add(new AircraftDto { Id = "BBB", Name = "Aircraft BBB" });
        }

        async public Task<IEnumerable<AircraftDto>> GetAll()
        {
            return await Task.FromResult(this.aircrafts.AsEnumerable());
        }
    }
}
