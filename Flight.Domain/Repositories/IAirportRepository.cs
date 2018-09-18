namespace Tui.Flight.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Frameworks.BusinessLogic;

    /// <summary>
    /// Repository interface for entity Airport
    /// </summary>
    public interface IAirportRepository : IRepository<Airport>
    {
        /// <summary>
        /// Get an airport from its identifier
        /// </summary>
        /// <param name="airportId">Identifier</param>
        /// <returns>An airport matching the identifier </returns>
        Airport GetById(String airportId);
    }
}
