using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrewData.Models;

namespace BrewHaHaNet.ViewModels {
  public struct ContestViewModel {

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<Vote> Votes { get; set; }

    public Contest ToContest() {
      return new Contest {
        Date = Date,
        Id = Id,
        Name = Name,
        Votes = Votes
      };
    }
  }
}