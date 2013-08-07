using System;
using System.ComponentModel;
using BrewData.Messages;
using BrewData.Models;
using System.Collections.Generic;

namespace BrewData.Repositories {
  public interface IContestRepository {
    OperationResult Create(Contest contest);
    IEnumerable<Contest> GetAll();
  }
  public class ContestRepository : IContestRepository {

    public ContestRepository() { }

    public OperationResult Create(Contest contest) {
      return new OperationResult { Message = "Contest Created (but not really)", Success = true };
    }

    public IEnumerable<Contest> GetAll() {
      return new List<Contest> {
        new Contest {
          Id = Guid.NewGuid(),
          Name = "Test Contest",
          Date = DateTime.Today,
          NumberOfBeers = 3,
          Votes = new BindingList<Vote>()
        }};
    }
  }
}
