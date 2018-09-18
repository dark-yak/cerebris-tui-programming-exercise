namespace Tui.WebApplication.FlightClient.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;

    public interface IAircraftApiService
    {
        Task<IEnumerable<AircraftDto>> GetAll();
    }
}
