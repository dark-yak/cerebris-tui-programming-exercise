namespace Tui.WebApplication.FlightClient.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;
    using Tui.WebApplication.FlightClient.Interfaces;

    public class AircraftApiService : ApiBaseService, IAircraftApiService
    {
        private const string GetAllEndpoint = "/aircrafts";

        public AircraftApiService(ApiSettings settings) : base(settings.ApiUrl)
        {
            
        }

        async public Task<IEnumerable<AircraftDto>> GetAll()
        {
            return await base.Get<IEnumerable<AircraftDto>>(GetAllEndpoint);
        }
    }
}
