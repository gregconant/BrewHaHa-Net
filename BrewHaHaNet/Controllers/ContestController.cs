﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewData.Helpers;
using BrewData.Models;
using Ninject;

namespace BrewHaHaNet.Controllers {
  public class ContestController : Controller {
    private readonly IContestFactory _contestFactory;

	[Inject]
    public ContestController(IContestFactory contestFactory) {
    _contestFactory = contestFactory;
  }

    //
    // GET: /Contest/

    public ActionResult Index() {
      return View();
    }

    //
    // GET: /Contest/Details/5

    public ActionResult Details(int id) {
      return View();
    }

    //
    // GET: /Contest/Create

    public ActionResult Create() {
      return View(new Contest { Date = DateTime.Today });
    }

    //
    // POST: /Contest/Create

    [HttpPost]
    public ActionResult Create(FormCollection collection) {
      try {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }

    //
    // GET: /Contest/Edit/5

    public ActionResult Edit(int id) {
      return View();
    }

    //
    // POST: /Contest/Edit/5

    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection) {
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
