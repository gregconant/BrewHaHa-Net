using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BrewData.Models;
using BrewHaHaNet.Factories;
using BrewHaHaNet.ViewModels;
using FluentAssertions;
using NUnit.Framework;

namespace BrewHaHaNet.Tests.Factories {

  [TestFixture]
  public class ContestListFactoryTest {


    [SetUp]
    public void SetUp() {

    }


    [Test]
    public void FromContestViewModels() {
      var sut = new ContestListFactory();
      var testGuid = Guid.NewGuid();
      var models = new List<ContestViewModel> {
        new ContestViewModel {
           Id = testGuid,
           Name = "Test 1",
           Date = DateTime.Today,
           NumberOfBeers = 10,
           Votes = new BindingList<Vote>()
         }
      };
      var resultList = sut.FromContestViewModels(models) as IEnumerable<SelectListItem>;
      resultList.Should().NotBeNull();

      resultList.Count().ShouldBeEquivalentTo(1);
      resultList.ElementAt(0).Text.ShouldBeEquivalentTo("Test 1");
      resultList.ElementAt(0).Value.ShouldBeEquivalentTo(testGuid.ToString());

    }
  }
}
