namespace Tui.WebApplication.FlightClient.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AircraftDto
    {
        public String Id { get; set; }

        public String Name { get; set; }

        public Double FuelConsumptionPerMile { get; set; }

        public Double FuelTakeOffEffort { get; set; }
    }
}
