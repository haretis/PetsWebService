using System.Collections.Generic;
using System.Net;
using PetsWebService.Common.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace PetsWebService.Common
{
    public interface IPetsService
    {       
        Task<List<People>> GetownersPetList(string url);
        List<PetDetails> FilterOwnersPetList(List<People> ownersPetList, string filterBy);
    }
}
