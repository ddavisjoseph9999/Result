using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using dotnet_code_challenge.Enums;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Models;
using Newtonsoft.Json;

namespace dotnet_code_challenge.Concrete
{
    public class FileHandler : IFileHandler
    {
        public ResultFileType GetFileType(string fileName)
        {
            ResultFileType retVal;
            if (Path.GetExtension(fileName).Equals(".json",
                StringComparison.OrdinalIgnoreCase))
            {
                retVal = ResultFileType.JSON;
            }
            else if (Path.GetExtension(fileName).Equals(".xml",
            StringComparison.OrdinalIgnoreCase))
            {
                retVal = ResultFileType.XML;
            }
            else
            {
                throw new Exception
                    ($"Invalid File Type {Path.GetExtension(fileName)}");
            }
            return retVal;
        }        

        public JsonDataModel.RaceFixture ReadJsonDataStream(MemoryStream dataStream)
        {
            string jsonString = Encoding.ASCII.GetString(dataStream.ToArray());
            JsonDataModel.RaceFixture raceFixture =
                JsonConvert.DeserializeObject<JsonDataModel.RaceFixture>
                (jsonString);
            return raceFixture;
        }

        public XmlDataModel.Meeting ReadXmlDataStream(MemoryStream dataStream)
        {
            string jxmlString = Encoding.ASCII.GetString(dataStream.ToArray());
            XmlSerializer serializer = new 
                XmlSerializer(typeof(XmlDataModel.Meeting));
            XmlDataModel.Meeting meeting = null;
            using (TextReader reader = new StringReader(jxmlString))
            {
                meeting = (XmlDataModel.Meeting)serializer.Deserialize(reader);
            }
            return meeting;           
        }        
    }
}
