using Biz.Interfaces;
using Biz.Services;
using Ninject.Modules;

namespace Web.Infrastructure
{
    public class WebModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// Note: please sort modules alphabetically
        /// </summary>
        public override void Load()
        {
            Bind<IAccountService>().To<AccountService>();
            Bind<IFacilityService>().To<FacilityService>();
        }
    }
}