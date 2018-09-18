namespace Tui.WebApplication.FlightClient.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;

    public interface IAirportApiService
    {
        Task<IEnumerable<AirportDto>> GetAll();
    }
}
