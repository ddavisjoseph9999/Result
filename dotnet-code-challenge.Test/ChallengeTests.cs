using dotnet_code_challenge.Concrete;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Enums;
using dotnet_code_challenge.Models;
using Xunit;
using System.Collections.Generic;

namespace dotnet_code_challenge.Test
{
    public class ChallengeTests
    {
        [Fact]
        public void FileHandler_GetFileType_ShouldReturnTrue()
        {
           IFileHandler fileHandler = new FileHandler();
           ResultFileType test =  fileHandler.GetFileType(@"c:\test\abc.json");
           Assert.True(test.Equals(ResultFileType.JSON));            
        }

        [Fact]
        public void FileHandler_ReadJsonDataStream_ShouldReturnNull()
        {
            IFileHandler fileHandler = new FileHandler();
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            JsonDataModel.RaceFixture rFixture = fileHandler.ReadJsonDataStream(stream);
            Assert.Null(rFixture);
        }

        [Fact]
        public void FileHandler_GetHorsesByPriceAscending_ShouldReturnNonEmptyList()
        {
            IOrderedResult orderedResult = new OrderedResult();
            JsonDataModel.ParticipantTags participantTags =
                new JsonDataModel.ParticipantTags();

            participantTags.Weight = "10";
            participantTags.Drawn = "Yes";
            participantTags.Jockey = "Bob";
            participantTags.Number = "101";
            participantTags.Trainer = "H";

            JsonDataModel.Participant participant = 
                new JsonDataModel.Participant();
            participant.Id = 1;
            participant.Name = "";
            participant.Tags = participantTags;

            JsonDataModel.SelectionTags selectionTags =
                new JsonDataModel.SelectionTags();

            selectionTags.participant = "Joe";
            selectionTags.name = "Bloggs";

            JsonDataModel.Selection selection =
                new JsonDataModel.Selection();

            selection.Id = "2";
            selection.Price = 19.2;
            selection.Tags = selectionTags;

            JsonDataModel.MarketTags marketTags =
                new JsonDataModel.MarketTags();

            marketTags.participant = "Jhon";
            marketTags.name = "Smith";

            JsonDataModel.Market market =
              new JsonDataModel.Market();

            market.Id = "3";
            market.Selections = new List<JsonDataModel.Selection>();
            market.Selections.Add(selection);
            market.Tags = marketTags;

            JsonDataModel.RawData rawData = new JsonDataModel.RawData();
            rawData.Markets = new List<JsonDataModel.Market>();
            rawData.Markets.Add(market);

            List<string> result =  orderedResult.GetHorsesByPriceAscending(rawData.Markets);
            
            Assert.NotEmpty(result);
        }

    }
}
