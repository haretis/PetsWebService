using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetsWebService.Common;
using System.Collections.Generic;
using PetsWebService.Common.Model;
using System.Threading.Tasks;

namespace PetsWebService.Common.Tests
{
    [TestClass]
    public class ServiceHelperTest
    {
        [TestMethod]
        public async Task TestEmptyUrl()
        {
            ServiceHelper objServiceHelper = new ServiceHelper();

            List<People> result = new List<People>();
                
            result = await objServiceHelper.GetownersPetList("");

            Assert.AreEqual(result.Count, 0);           
        }

        [TestMethod]
        public async Task GetownersPetList()
        {
            ServiceHelper objServiceHelper = new ServiceHelper();

            List<People> result = new List<People>();

            result = await objServiceHelper.GetownersPetList("http://agl-developer-test.azurewebsites.net/people.json");
            
            Assert.AreNotEqual(result?.Count, 0);            
        }
    }
}
