namespace Tui.Flight.Domain.Models
{
    using System;
    using Tui.Flight.Domain.Services;
    using Tui.Frameworks.BusinessLogic;

    /// <summary>
    /// Root entity : Airport
    /// </summary>
    public class Airport : Entity<String>, IAggregateRoot
    {
        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public Double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public Double Longitude { get; set; }

        /// <summary>
        /// Construct an empty entity Airport
        /// </summary>
        public Airport()
        {
        }

        /// <summary>
        /// Construct an entity Aircraft
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="name">Name</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        public Airport(String id, String name, Double latitude, Double longitude)
        {
            this.Id = id;
            this.Name = name;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Get the distance in miles with another airport
        /// </summary>
        /// <param name="airport">Remote airport</param>
        /// <returns>Distance in miles</returns>
        public Double GetDistance(Airport airport)
        {
            var distanceService = new DistanceService();

            return distanceService.Distance(this.Latitude, this.Longitude, airport.Latitude, airport.Longitude, 'M');
        }
    }
}
