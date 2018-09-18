namespace Tui.Flight.Domain.Models
{
    using System;
    using Tui.Frameworks.BusinessLogic;

    /// <summary>
    /// Root entity : Aircraft
    /// </summary>
    public class Aircraft : Entity<String>, IAggregateRoot
    {
        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Fuel consumption per mile
        /// </summary>
        public Double FuelConsumptionPerMile { get; set; }

        /// <summary>
        /// Fuel consumption during take off
        /// </summary>
        public Double FuelTakeOffEffort { get; set; }

        /// <summary>
        /// Construct an empty entity Aircraft
        /// </summary>
        public Aircraft()
        {
        }

        /// <summary>
        /// Construct an entity Aircraft
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="name">Name</param>
        /// <param name="fuelConsumptionPerMile">Fuel consumption per mile</param>
        /// <param name="fuelTakeOffEffort">Fuel consumption during take off</param>
        public Aircraft(String id, String name, Double fuelConsumptionPerMile, Double fuelTakeOffEffort)
        {
            this.Id = id;
            this.Name = name;
            this.FuelConsumptionPerMile = fuelConsumptionPerMile;
            this.FuelTakeOffEffort = fuelTakeOffEffort;
        }
    }
}
