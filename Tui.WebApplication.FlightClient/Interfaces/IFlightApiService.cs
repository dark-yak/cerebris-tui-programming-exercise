namespace Tui.WebApplication.FlightClient.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;

    public interface IFlightApiService
    {
        Task<IEnumerable<FlightDto>> GetAll();

        Task<FlightDto> GetById(Guid id);

        Task<IEnumerable<FlightReportDto>> GetReport();

        Task Create(FlightDto flight);

        Task Update(FlightDto flight);
    }
}
