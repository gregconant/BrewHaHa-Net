using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoq;
using BrewData.Helpers;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using BrewData.Models;

namespace BrewData.Tests {
  [TestFixture]
  public class ContestFactoryTest {
    private AutoMoq.AutoMoqer moqer;
    private Mock<IGuidFactory> guidFactory;
    private ContestFactory sut;

    [SetUp]
    public void Init() {
      moqer = new AutoMoqer();
      guidFactory = moqer.GetMock<IGuidFactory>();
      sut = moqer.Resolve<ContestFactory>();
    }

    [Test]
    public void Create_SetsDefaultCreatedDate() {
      var result = sut.Create();
      result.Date.ShouldBeEquivalentTo(DateTime.Today);
    }

    [Test]
    public void Create_SetsDefaultVotes() {
      var result = sut.Create();
      result.Votes.ShouldBeEquivalentTo(new List<Vote>());

    }

    [Test]
    public void Create_SetsDefaultGuid() {
      var testGuid = new Guid();
      guidFactory.Setup(f => f.NewGuid()).Returns(testGuid);
      var result = sut.Create();
      guidFactory.Verify(f => f.NewGuid());
      result.Id.ShouldBeEquivalentTo(testGuid);

    }
  }
}
