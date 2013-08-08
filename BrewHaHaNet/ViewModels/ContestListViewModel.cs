using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrewHaHaNet.ViewModels {
  public class ContestListViewModel {
    public IEnumerable<SelectListItem> Contests { get; set; }
  }
}