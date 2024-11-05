using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Ninject.Modules;
using Model;
using DataAccessLayer.EF;
using DataAccessLayer.Dapper;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IRepository<Student>>().To<DapperRepository<Student>>().InSingletonScope();
        }
    }
}
