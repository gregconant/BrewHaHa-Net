using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    private AutoMoqer mocker;
    private Mock<IContestFactory> contestFactory;
    private Mock<IContestRepository> repo;
    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    [SetUp]
    public void SetUp() {
      mocker = new AutoMoqer();
      contestFactory = mocker.GetMock<IContestFactory>();
      repo = mocker.GetMock<IContestRepository>();
    }

    [Test]
    public void Create_PopulatesDateWithTodaysDate() {

      contestFactory
        .Setup(f => f.Create())
        .Returns(new Contest { Date = DateTime.Today });

      var controller = mocker.Resolve<ContestController>();

      var result = controller.Create() as ViewResult;

      contestFactory.Verify(f => f.Create());

      result.Should().NotBeNull();
      var actualModel = result.Model as ContestViewModel;
      actualModel.Should().NotBeNull();
      actualModel.Date.ShouldBeEquivalentTo(DateTime.Today);

    }

    [Test]
    public void Create_UsesRepo() {
      var controller = mocker.Resolve<ContestController>();

      repo
        .Setup(r => r.Create(It.IsAny<Contest>()))
        .Returns(new OperationResult { Success = true, Message = "Something good" });

      var result = controller.Create(new ContestViewModel {
        Id = new Guid(),
        Name = "My Contest",
        Date = DateTime.Today,
        Votes = new BindingList<Vote> { new Vote { Id = new Guid(), Choice = new Beer { Id = new Guid(), Name = "Awesome Beer" } } }
      });
      repo.Verify(r => r.Create(It.IsAny<Contest>()));
    }

    [Test]
    public void Index_ReturnsListOfContests() {

      var expectedResults = new List<Contest> {
                                                new Contest {
                                                              Id = Guid.NewGuid(),
                                                              Name = "Test"
                                                            }
                                              };
      repo.Setup(r => r.GetAll()).Returns(expectedResults);

      var sut = mocker.Resolve<ContestController>();

      var result = sut.Index() as ViewResult;
      repo.Verify(r => r.GetAll());
      Assert.NotNull(result);
      var model = result.Model as IEnumerable<ContestViewModel>;
      Assert.NotNull(model);
      model.Should().HaveCount(1);
      model.ElementAt(0).Name.Should().BeEquivalentTo("Test");
    }

  }
}