using System.IO;
using dotnet_code_challenge.Enums;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Interfaces
{
    public interface IFileHandler
    {
        ResultFileType GetFileType(string fileName);
        JsonDataModel.RaceFixture ReadJsonDataStream(MemoryStream dataStream);
        XmlDataModel.Meeting ReadXmlDataStream(MemoryStream dataStream);
    }
}
