using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Tui.Frameworks.BusinessLogic;

namespace Tui.Flight.Infrastructure.Repositories
{
    public class XmlRepositoryHelper<T> 
    {
        private String xmlBackendFile;

        public XmlRepositoryHelper(String xmlBackendFile)
        {
            this.xmlBackendFile = xmlBackendFile;
        }

        public List<T> GetAll() 
        {
            List<T> items;

            using (StreamReader stream = new StreamReader(this.xmlBackendFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                items = (List<T>)serializer.Deserialize(stream);
                stream.Close();
            }

            return items;
        }

        public void SaveAll(List<T> items)
        {
            using (StreamWriter streamWriter= new StreamWriter(xmlBackendFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                serializer.Serialize(streamWriter, items);

                streamWriter.Close();
            }
        }
    }
}
