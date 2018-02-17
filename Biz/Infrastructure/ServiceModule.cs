using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains;
using Data;
using Ninject.Modules;

namespace Biz.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// Please add modules in alphabetical order
        /// </summary>
        public override void Load()
        {
            Bind<IRepository<Account>>().To<Repository<Account>>();
            Bind<IRepository<Facility>>().To<Repository<Facility>>();
        }
    }
}
