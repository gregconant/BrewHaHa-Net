using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewData.Models;

namespace BrewHaHaNet.ViewModels {
  public struct ContestViewModel {

    private IEnumerable<SelectListItem> beerChoices;

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfBeers { get; set; }
    public IEnumerable<SelectListItem> BeerChoices { get { return Enumerable.Range(0, 10).Select(num => new SelectListItem { Value = num.ToString(), Text = num.ToString() }); } set { beerChoices = value; } }
    public IEnumerable<Vote> Votes { get; set; }

    public static ContestViewModel FromContest(Contest contest) {
      return new ContestViewModel {
        Date = contest.Date,
        Id = contest.Id,
        Name = contest.Name,
        Votes = contest.Votes,
        NumberOfBeers = contest.NumberOfBeers,
      };
    }

    public Contest ToContest() {
      return new Contest {
        Date = Date,
        Id = Id,
        Name = Name,
        Votes = Votes,
        NumberOfBeers = NumberOfBeers,

      };
    }
  }
}