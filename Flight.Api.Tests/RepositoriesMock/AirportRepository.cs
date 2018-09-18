namespace Flight.Api.Tests.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;

    public class AircraftRepository : IAircraftRepository
    {
        private IEnumerable<Aircraft> aircrafts;

        public AircraftRepository(IEnumerable<Aircraft> aircrafts) 
        {
            this.aircrafts = aircrafts;
        }

        public IEnumerable<Aircraft> GetAll()
        {
            return aircrafts;
        }

        public Aircraft GetById(String aircraftId)
        {
            return this.GetAll().FirstOrDefault(a => a.Id == aircraftId);
        }
    }
}
