namespace Tui.WebApplication.Tests.ServicesMock
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tui.WebApplication.FlightClient.Dto;
    using Tui.WebApplication.FlightClient.Interfaces;

    public class AirportApiService : IAirportApiService
    {
        private List<AirportDto> airports;

        public AirportApiService()
        {
            this.airports = new List<AirportDto>();
            this.airports.Add(new AirportDto { Id = "LAX", Name = "Los Angeles International Airport (United States)", Latitude = 33.94250107, Longitude = -118.4079971 });
            this.airports.Add(new AirportDto { Id = "HND", Name = "Tokyo Haneda International Airport (Japan)", Latitude = 35.552299, Longitude = 139.779999 });
        }

        async public Task<IEnumerable<AirportDto>> GetAll()
        {
            return await Task.FromResult(this.airports.AsEnumerable());
        }
    }
}
