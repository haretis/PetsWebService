using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using PetsWebService.ViewModel;
using System.Configuration;
using PetsWebService.Common;
using PetsWebService.Common.Model;
using System.Threading.Tasks;

namespace PetsWebService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceHelper svc;
        public HomeController(IServiceHelper _svc)
        {
            this.svc = _svc;            
        }
        public async Task<ActionResult> Index()
        {
            string url = ConfigurationManager.AppSettings["Url"];
            string filterBy = ConfigurationManager.AppSettings["FilterBy"];

            List<People> ownersPetList = await this.svc.GetownersPetList(url);

            List<PetDetails> resFilteredOwnerPetDetails = (from owner in ownersPetList
                    where owner.Pets != null
                    from pet in owner.Pets
                    where pet.Type.ToUpper() == filterBy
                    orderby pet.Name
                    select new
                    {
                        gender = owner.Gender,
                        petname = pet.Name
                    }).GroupBy(g => g.gender).Select(t => new PetDetails { gender = t.Key, pets = t.Select(p => p.petname).ToList() }).ToList();
            
            return View(resFilteredOwnerPetDetails);
        }       
    }
}