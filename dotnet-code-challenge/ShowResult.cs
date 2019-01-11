using System;
using System.Collections.Generic;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Enums;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_code_challenge
{
    public class ShowResult
    {
        private readonly IFileHandler _fileHandler;
        private readonly IOrderedResult _orderedResult;

        public ShowResult(ServiceProvider service)
        {
            _fileHandler = service.GetService<IFileHandler>();
            _orderedResult = service.GetService<IOrderedResult>();   
        }

       public void Init(string[] fileList)
       {
            foreach (var file in fileList)
            {
                RenderHorseList(file);
            }
        }

        private void RenderHorseList(string file)
        {
            MemoryStream data = GetStreamFromFile(file);
            if (_fileHandler.GetFileType(file) == ResultFileType.JSON)
            {
                JsonDataModel.RaceFixture raceFixture = _fileHandler.ReadJsonDataStream(data);
                List<string> jHorsesByPriceAscending = _orderedResult.GetHorsesByPriceAscending(raceFixture.RawData.Markets);
                foreach (string h in jHorsesByPriceAscending)
                {
                    Console.WriteLine($"The name of the Wolverhamption Race horse in ascending order of price is {h}");
                }
            }
            else
            {
                XmlDataModel.Meeting meeting = _fileHandler.ReadXmlDataStream(data);
                List<string> xHorsesByPriceAscending = _orderedResult.GetHorsesByPriceAscending(meeting);
                foreach (string h in xHorsesByPriceAscending)
                {
                    Console.WriteLine($"The name of the Caulfield Race horse in ascending order of price is {h}");
                }
            }
            data.Close();
        }

        private static MemoryStream GetStreamFromFile(string fileName)
        {
            System.IO.MemoryStream data = new System.IO.MemoryStream();
            System.IO.Stream str = File.OpenRead(fileName);
            str.CopyTo(data);
            // Reset memory stream
            data.Position = 0;
            byte[] buf = new byte[data.Length];
            data.Read(buf, 0, buf.Length);
            str.Close();
            return data;
        }
    }
}
