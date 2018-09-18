namespace Tui.WebApplication.Models
{
    using System;
    using Tui.WebApplication.FlightClient.Dto;

    public class AircraftViewModel
    {
        public String Id { get; set; }

        public String Name { get; set; }

        public Double FuelConsumptionPerMile { get; set; }

        public Double FuelTakeOffEffort { get; set; }

        public AircraftViewModel(AircraftDto aircraftDto)
        {
            this.Id = aircraftDto.Id;
            this.Name = aircraftDto.Name;
            this.FuelConsumptionPerMile = aircraftDto.FuelConsumptionPerMile;
            this.FuelTakeOffEffort = aircraftDto.FuelTakeOffEffort;
        }
    }
}
