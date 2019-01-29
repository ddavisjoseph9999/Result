using dotnet_code_challenge.Models;
using System.Collections.Generic;

namespace dotnet_code_challenge.Interfaces
{
    public interface IOrderedResult
    {
       List<string> GetHorsesByPriceAscending
            (IList<JsonDataModel.Market>  markets);

       List<string> GetHorsesByPriceAscending
             (XmlDataModel.Meeting meeting);
    }
}
