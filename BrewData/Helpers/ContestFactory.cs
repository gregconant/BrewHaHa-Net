using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BrewData.Models;

namespace BrewData.Helpers {
  public interface IContestFactory {
    Contest Create();
  }

  public class ContestFactory : IContestFactory {

    private IGuidFactory guidFactory;

    public ContestFactory(IGuidFactory factory) {
      guidFactory = factory;
    }

    public Contest Create() {
      return new Contest {
        Id = guidFactory.NewGuid(),
        Date = DateTime.Today,
        Votes = new BindingList<Vote>(),
      };
    }
  }
}
