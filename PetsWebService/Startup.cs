using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetsWebService.Startup))]
namespace PetsWebService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
