using System.Collections.Generic;
using System.Net;
using PetsWebService.Common.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System;

namespace PetsWebService.Common
{
    public class ServiceHelper : IServiceHelper
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
                    objPetOwnerList = await res.Content.ReadAsAsync<List<People>>(formatters);
                }
            }
            catch(Exception ex)
            {
                // handle exceptions here
            }
            
            return objPetOwnerList;        
        }       
    }
}
