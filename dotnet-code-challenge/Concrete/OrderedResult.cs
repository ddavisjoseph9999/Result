using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Concrete
{
    public class OrderedResult : IOrderedResult
    {
        public List<string> GetHorsesByPriceAscending(IList<JsonDataModel.Market> markets)
        {
            List<string> horses = new List<string>();
            foreach(JsonDataModel.Market m in markets)
            {
                horses.AddRange(m.Selections.OrderBy(x => x.Price).Select(x => x.Tags.name).ToList());
            }
            return horses;
        }

        public List<string> GetHorsesByPriceAscending(XmlDataModel.Meeting meeting)
        {
           return meeting.Races.Race.Horses.Horse.
                OrderBy(x => x.Price)
                .Select( x=> x.Name).ToList<string>();           
        }

       
    }
}
