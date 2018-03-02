using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Configuration;
using PetsWebService.Common;
using PetsWebService.Common.Model;
using System.Threading.Tasks;

namespace PetsWebService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetsService _petService;
        public HomeController(IPetsService petService)
        {
            _petService = petService;            
        }

        public async Task<ActionResult> Index()
        {
            string url = ConfigurationManager.AppSettings["Url"];
            string filterBy = ConfigurationManager.AppSettings["FilterBy"];

            List<People> ownersPetList = await _petService.GetownersPetList(url);

            List<Common.Model.PetDetails> resFilteredOwnerPetDetails =
                _petService.FilterOwnersPetList(ownersPetList, filterBy);

            return View(resFilteredOwnerPetDetails);
        }
    }
}