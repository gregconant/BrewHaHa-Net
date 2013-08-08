using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewHaHaNet.ViewModels;

namespace BrewHaHaNet.Factories {

  public interface IContestListFactory {
    IEnumerable<SelectListItem> FromContestViewModels(IEnumerable<ContestViewModel> contests);
  }

  public class ContestListFactory : IContestListFactory {

    public IEnumerable<SelectListItem> FromContestViewModels(IEnumerable<ContestViewModel> contests) {
      var listItems = contests.Select(ToListItem).ToList();
      return listItems;

    }

    private SelectListItem ToListItem(ContestViewModel viewModel) {
      return new SelectListItem { Text = viewModel.Name, Value = viewModel.Id.ToString() } ;
    }

  }
}