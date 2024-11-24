using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace aislab1
{
    public class ConsoleViewConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConsoleView>().To<ConsoleView>().InSingletonScope();
        }
    }
}
