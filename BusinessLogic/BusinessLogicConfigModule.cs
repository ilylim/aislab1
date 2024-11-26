using DataAccessLayer.EF;
using DataAccessLayer.Dapper;
using DataAccessLayer;
using Entities;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Planning.Bindings;

namespace BusinessLogic
{
    public class BusinessLogicConfigModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRepository<Student>>().To<EntityRepository<Student>>().InSingletonScope();
            Bind<IRepository<Student>>().To<DapperRepository<Student>>().InSingletonScope();
            Bind<IManager<Student>>().To<StudentsManager>().InSingletonScope();
        }
    }
}
