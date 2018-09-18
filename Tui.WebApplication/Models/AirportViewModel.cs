namespace Tui.WebApplication.Models
{
    using System;
    using Tui.WebApplication.FlightClient.Dto;

    public class AirportViewModel
    {
        public String Id { get; set; }

        public String Name { get; set; }

        public Double Longitude { get; set; }

        public Double Latitude { get; set; }

        public AirportViewModel(AirportDto airportDto)
        {
            this.Id = airportDto.Id;
            this.Name = airportDto.Name;
            this.Longitude = airportDto.Longitude;
            this.Latitude = airportDto.Latitude;
        }
    }
}
