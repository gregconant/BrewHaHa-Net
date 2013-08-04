using System;
using System.ComponentModel;
using System.Web.Mvc;
using AutoMoq;
using BrewData.Helpers;
using BrewData.Messages;
using BrewData.Models;
using BrewHaHaNet.Controllers;
using BrewHaHaNet.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using BrewData.Repositories;

namespace BrewHaHaNet.Tests.Controllers {
  /// <summary>
  ///This is a test class for ContestControllerTest and is intended
  ///to contain all ContestControllerTest Unit Tests
  ///</summary>
  [TestFixture]
  public class ContestControllerTest {
    private AutoMoqer _mocker = new AutoMoqer();

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    [SetUp]
    public void SetUp() {

    }


    [Test]
    public void Create_PopulatesDateWithTodaysDate() {

      var contestFactory = _mocker.GetMock<IContestFactory>();

      contestFactory.Setup(f => f.Create()).Returns(new Contest { Date = DateTime.Today });
      var controller = _mocker.Resolve<ContestController>();

      var result = controller.Create() as ViewResult;

      contestFactory.Verify(f => f.Create());

      Assert.NotNull(result);
      var actualModel = result.Model as Contest;
      Assert.NotNull(actualModel);
      actualModel.Date.ShouldBeEquivalentTo(DateTime.Today);

    }

    [Test]
    public void Create_UsesRepo() {
      var contestFactory = _mocker.GetMock<IContestFactory>();
      var repo = _mocker.GetMock<IContestRepository>();
      var controller = _mocker.Resolve<ContestController>();

      repo
        .Setup(r => r.Create(It.IsAny<Contest>()))
        .Returns(new OperationResult { Success = true, Message = "Something good"} );

      var result = controller.Create(new ContestViewModel {
        Id = new Guid(),
        Name = "My Contest",
        Date = DateTime.Today,
        Votes = new BindingList<Vote> { new Vote { Id = new Guid(), Choice = new Beer { Id = new Guid(), Name = "Awesome Beer" } } }
      });
      repo.Verify(r => r.Create(It.IsAny<Contest>()));

    }
  }
}