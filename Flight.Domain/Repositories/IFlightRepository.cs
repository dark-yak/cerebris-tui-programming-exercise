namespace Tui.Flight.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Frameworks.BusinessLogic;

    /// <summary>
    /// Repository interface for entity Flight
    /// </summary>
    public interface IFlightRepository : IRepository<Flight>
    {
        /// <summary>
        /// Get a flight from its identifier
        /// </summary>
        /// <param name="flightId">Identifier</param>
        /// <returns>A flight matching the identifier </returns>
        Flight GetById(Guid flightId);

        /// <summary>
        ///  Add a flight
        /// </summary>
        /// <param name="flight">the flight to add</param>
        void Add(Flight flight);

        /// <summary>
        /// Update a flight
        /// </summary>
        /// <param name="flight">the flight to update</param>
        void Update(Flight flight);
    }
}
