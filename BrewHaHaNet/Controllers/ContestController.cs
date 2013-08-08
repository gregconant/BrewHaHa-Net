using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewData.Helpers;
using BrewData.Models;
using BrewData.Repositories;
using BrewHaHaNet.Factories;
using BrewHaHaNet.ViewModels;
using Ninject;

namespace BrewHaHaNet.Controllers {
  public class ContestController : Controller {
    private readonly IContestFactory contestFactory;
    private readonly IContestRepository contestRepository;
    private readonly IContestListFactory contestListFactory;

    [Inject]
    public ContestController(IContestFactory contestFactory, IContestRepository contestRepository, IContestListFactory contestListFactory) {
      this.contestFactory = contestFactory;
      this.contestRepository = contestRepository;
      this.contestListFactory = contestListFactory;
    }

    //
    // GET: /Contest/

    public ActionResult Index() {
      var contests = contestRepository.GetAll();
      var viewModels = contests.Select(ContestViewModel.FromContest);
      var selectList = contestListFactory.FromContestViewModels(viewModels);

      return View(new ContestListViewModel {
        Contests = selectList
      });

    }

    //
    // GET: /Contest/Details/5

    public ActionResult Details(int id) {
      return View();
    }

    //
    // GET: /Contest/Create

    public ActionResult Create() {
      var contest = contestFactory.Create();
      return View(ContestViewModel.FromContest((contest)));
    }

    //
    // POST: /Contest/Create

    [HttpPost]
    public ActionResult Create(ContestViewModel contest) {
      try {
        // TODO: Add insert logic here
        var created = contestRepository.Create(contest.ToContest());
        TempData["CreateResult"] = "Contest Created.";
        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }

    //
    // GET: /Contest/Load/5

    public ActionResult Load(int id) {
      return View();
    }

    //
    // POST: /Contest/Edit/5

    [HttpPost]
    public ActionResult Save(int id, FormCollection collection) {
      try {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }

    //
    // GET: /Contest/Delete/5

    public ActionResult Delete(int id) {
      return View();
    }

    //
    // POST: /Contest/Delete/5

    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection) {
      try {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }
  }
}
