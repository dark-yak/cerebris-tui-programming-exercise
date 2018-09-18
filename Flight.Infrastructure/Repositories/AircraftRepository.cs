namespace Tui.Flight.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Repositories;

    public class AircraftRepository : IAircraftRepository
    {
        private XmlRepositoryHelper<Aircraft> xmlHelper;

        public AircraftRepository() 
        {
            this.xmlHelper = new XmlRepositoryHelper<Aircraft>(@"SampleData\Aircrafts.xml");
        }

        public IEnumerable<Aircraft> GetAll()
        {
            return this.xmlHelper.GetAll();
        }

        public Aircraft GetById(String aircraftId)
        {
            return this.GetAll().FirstOrDefault(a => a.Id == aircraftId);
        }
    }
}
