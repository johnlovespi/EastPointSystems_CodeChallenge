using System;
using CodeChallenge.Data.Repositories;
using CodeChallenge.Entities;
using Ploeh.AutoFixture;
using Xunit;

namespace CodeChallenge.Tests
{
  public class RegionRepositoryTests
  {
    [Fact]
    public void Get_RegionFound_ReturnsCorrectRegion()
    {
      Fixture fixture = new Fixture();
      var sut = new RegionRepository();
      Region region = fixture.Create<Region>();
      sut.Add(region);

      Region returned = sut.Get(region.Id);

      Assert.Equal(region.Id, returned.Id);
    }

    [Fact]
    public void Get_NotFound_ReturnsNull()
    {
      Fixture fixture = new Fixture();
      var sut = new RegionRepository();
      Guid regionId = fixture.Create<Guid>();

      Region returned = sut.Get(regionId);

      Assert.Null(returned);
    }

    [Fact]
    public void Add_AddsRegion()
    {
      Fixture fixture = new Fixture();
      var sut = new RegionRepository();
      Region region = fixture.Create<Region>();
      sut.Add(region);

      Region returned = sut.Get(region.Id);

      Assert.NotNull(returned);
    }

    [Fact]
    public void Add_AlreadyExists_Updates()
    {
      Fixture fixture = new Fixture();
      var sut = new RegionRepository();
      Region region = fixture.Create<Region>();
      sut.Add(region);
      Region secondRegion = fixture.Create<Region>();
      secondRegion.Id = region.Id;

      sut.Add(secondRegion);
      Region returned = sut.Get(secondRegion.Id);

      Assert.Equal(secondRegion.Name, returned.Name);
    }

    [Fact]
    public void Remove_RemovesRegion()
    {
      Fixture fixture = new Fixture();
      var sut = new RegionRepository();
      Region region = fixture.Create<Region>();
      sut.Add(region);

      Assert.NotNull(sut.Get(region.Id));

      sut.Remove(region.Id);

      Assert.Null(sut.Get(region.Id));
    }

    [Fact]
    public void Remove_RegionNotFound_ThrowsException()
    {
      Fixture fixture = new Fixture();
      var sut = new RegionRepository();
      Guid regionId = fixture.Create<Guid>();

      Assert.Throws(typeof(InvalidOperationException), () => sut.Remove(regionId));
    }
  }
}
