using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewData.Helpers;
using BrewData.Repositories;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using BrewHaHaNet.Factories;

namespace BrewHaHaNet {
  public class BrewHaHaNinjectModule : NinjectModule {
    public BrewHaHaNinjectModule() { }

    public override void Load() {

      Bind<IContestFactory>()
            .To<ContestFactory>()
            .InTransientScope();

      Bind<IContestRepository>()
        .To<ContestRepository>()
        .InTransientScope();

      Bind<IGuidFactory>()
        .To<GuidFactory>()
        .InSingletonScope();

      Bind<IContestListFactory>()
        .To<ContestListFactory>()
        .InTransientScope();
    }
  }
}