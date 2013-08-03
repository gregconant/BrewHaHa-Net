using System;
using System.Web.Mvc;
using AutoMoq;
using BrewData.Helpers;
using BrewData.Models;
using BrewHaHaNet.Controllers;
using FluentAssertions;
using NUnit.Framework;

namespace BrewHaHaNet.Tests.Controllers {
  /// <summary>
  ///This is a test class for ContestControllerTest and is intended
  ///to contain all ContestControllerTest Unit Tests
  ///</summary>
  [TestFixture]
  public class ContestControllerTest {
    private AutoMoqer _mocker;
    
    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    [SetUp]
    public void SetUp() {
    _mocker  = new AutoMoqer();
      
    }


    [Test]
    public void Create_PopulatesDateWithTodaysDate() {

      var contestFactory = _mocker.GetMock<IContestFactory>();

      contestFactory.Setup(f => f.Create()).Returns(new Contest { Name = "this is a thing that is created"});
      var controller = _mocker.Resolve<ContestController>();

      var result = controller.Create() as ViewResult;

      contestFactory.Verify(f => f.Create());

      Assert.NotNull(result);
      var actualModel = result.Model as Contest;
      Assert.NotNull(actualModel);
      actualModel.Date.ShouldBeEquivalentTo(DateTime.Today);

    }
  }
}