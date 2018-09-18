namespace Tui.WebApplication.FlightClient.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;
    using Tui.WebApplication.FlightClient.Interfaces;

    public class FlightApiService : ApiBaseService, IFlightApiService
    {
        private const string FlightsEndpoint = "/flights";

        public FlightApiService(ApiSettings settings) : base(settings.ApiUrl)
        {
        }

        async public Task<IEnumerable<FlightDto>> GetAll()
        {
            return await base.Get<IEnumerable<FlightDto>>(FlightsEndpoint);
        }

        async public Task<FlightDto> GetById(Guid guid)
        {
            return await base.Get<FlightDto>(FlightsEndpoint + "/" + guid.ToString());
        }

        async public Task Create(FlightDto flightDto)
        {
            await base.Post(FlightsEndpoint, flightDto);
        }

        async public Task Update(FlightDto flightDto)
        {
            await base.Put(FlightsEndpoint, flightDto);
        }

        async public Task<IEnumerable<FlightReportDto>> GetReport()
        {
            return await base.Get<IEnumerable<FlightReportDto>>(FlightsEndpoint + "/report");
        }
    }
}
