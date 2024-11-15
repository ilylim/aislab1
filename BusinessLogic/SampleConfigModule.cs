using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Ninject.Modules;
using DataAccessLayer.EF;
using DataAccessLayer.Dapper;
using Entities;

namespace BusinessLogic
{
    public class SampleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Student>>().To<DapperRepository<Student>>().InSingletonScope();
            Bind<IManager<Student>>().To<StudentsManager>().InSingletonScope();
        }
    }
}
