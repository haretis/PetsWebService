using System.Collections.Generic;
using System.Net;
using PetsWebService.Common.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System;
using System.Linq;

namespace PetsWebService.Common
{
    public class PetsService : IPetsService
    {
        /// <summary>
        /// This method calls the web service and retrieves data in list<people> format.
        /// </summary>
        /// <param name="url"> web service url to acess</param>
        /// <returns>it returns of type List<people></returns>
        public async Task<List<People>> GetownersPetList(string url)
        {
            List<People> objPetOwnerList = new List<People>();
            var formatters = new List<MediaTypeFormatter>()
            {
                new JsonMediaTypeFormatter()
            };

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    List<People> response = await res.Content.ReadAsAsync<List<People>>(formatters);

                    if (response != null)
                        objPetOwnerList = response;
                }
            }
            catch(Exception ex)
            {
                // handle exceptions here
            }
            
            return objPetOwnerList;        
        }

        public List<PetDetails> FilterOwnersPetList(List<People> ownersPetList, string filterBy)
        {
           var response =  (from owner in ownersPetList
                where owner.Pets != null
                from pet in owner.Pets
                where pet.Type.ToUpper() == filterBy
                orderby pet.Name
                select new
                {
                    gender = owner.Gender,
                    petname = pet.Name
                }).GroupBy(g => g.gender).Select(t => new PetDetails { Gender = t.Key, Pets = t.Select(p => p.petname).ToList() }).ToList();

            return response;

        }
    }
}
