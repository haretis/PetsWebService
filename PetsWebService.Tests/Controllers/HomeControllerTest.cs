using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetsWebService;
using PetsWebService.Controllers;
using PetsWebService.Common;
using System.Threading.Tasks;
using Moq;
using Microsoft.Practices.Unity;

namespace PetsWebService.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var mockServiceHelper = new Mock<IPetsService>(MockBehavior.Strict);
            var unity = new UnityContainer();
            unity.RegisterInstance(mockServiceHelper.Object);

            HomeController controller = new HomeController(mockServiceHelper.Object);
                        
            Task<ActionResult> result = controller.Index() as Task<ActionResult>;
                        
            Assert.IsNotNull(result);
        }     
    }
}
