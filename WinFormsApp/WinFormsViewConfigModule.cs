﻿using Ninject.Modules;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public class WinFormsViewConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainView>().To<StartForm>().InSingletonScope();
        }
    }
}
