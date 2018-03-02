using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetsWebService.Common;
using System.Collections.Generic;
using PetsWebService.Common.Model;
using System.Threading.Tasks;

namespace PetsWebService.Common.Tests
{
    [TestClass]
    public class PetsServiceTest
    {
        [TestMethod]
        public async Task TestEmptyUrl()
        {
            PetsService objPetService = new PetsService();

            List<People> result = new List<People>();
                
            result = await objPetService.GetownersPetList("");

            Assert.AreEqual(result.Count, 0);           
        }

        [TestMethod]
        public async Task GetownersPetList()
        {
            PetsService objPetService = new PetsService();

            List<People> result = new List<People>();

            result = await objPetService.GetownersPetList("http://agl-developer-test.azurewebsites.net/people.json");
            
            Assert.AreNotEqual(result?.Count, 0);            
        }
    }
}
