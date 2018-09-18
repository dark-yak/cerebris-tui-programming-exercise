namespace Tui.Flight.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Frameworks.BusinessLogic;

    /// <summary>
    /// Repository interface for the entity Aircraft
    /// </summary>
    public interface IAircraftRepository : IRepository<Aircraft>
    {
        /// <summary>
        /// Get an aircraft from its identifier
        /// </summary>
        /// <param name="aircraftId">Identifier</param>
        /// <returns>An aircraft matching the identifier</returns>
        Aircraft GetById(String aircraftId);
    }
}
