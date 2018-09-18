namespace Tui.Flight.Domain.Models
{
    using System;
    using Tui.Frameworks.BusinessLogic;

    /// <summary>
    /// Root entity : Flight 
    /// </summary>
    public class Flight : Entity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Departure airport
        /// </summary>
        public Airport DepartureAirport { get; set; }

        /// <summary>
        /// Destination airport
        /// </summary>
        public Airport DestinationAirport { get; set; }

        /// <summary>
        /// Aircraft used for the flight
        /// </summary>
        public Aircraft Aircraft { get; set; }

        /// <summary>
        /// Construct an empty entity Flight
        /// </summary>
        public Flight()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Construct an entity Flight
        /// </summary>
        /// <param name="departureAirport">Departure airport</param>
        /// <param name="destinationAirport">Destination airport</param>
        /// <param name="aircraft">Aircraft used for the flight</param>
        public Flight(Airport departureAirport, Airport destinationAirport, Aircraft aircraft): this()
        {
            this.DepartureAirport = departureAirport;
            this.DestinationAirport = destinationAirport;
            this.Aircraft = aircraft;
        }

        /// <summary>
        /// Compute the fuel consumption for the flight (takeoff + travel)
        /// </summary>
        /// <returns>Fuel consumption (arbitrary units)</returns>
        public Double ComputeFuelConsumption()
        {
            return this.Aircraft.FuelConsumptionPerMile * this.DepartureAirport.GetDistance(this.DestinationAirport) + this.Aircraft.FuelTakeOffEffort;
        }
    }
}
