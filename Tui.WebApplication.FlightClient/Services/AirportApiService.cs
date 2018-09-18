namespace Tui.WebApplication.FlightClient.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;
    using Tui.WebApplication.FlightClient.Interfaces;

    public class AirportApiService : ApiBaseService, IAirportApiService
    {
        private const string GetAllEndpoint = "/airports";

        public AirportApiService(ApiSettings settings) : base(settings.ApiUrl)
        {
        }

        async public Task<IEnumerable<AirportDto>> GetAll()
        {
            return await base.Get<IEnumerable<AirportDto>>(GetAllEndpoint);
        }
    }
}
