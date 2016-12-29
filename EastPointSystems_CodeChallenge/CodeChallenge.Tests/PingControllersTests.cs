using CodeChallenge.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenge.Tests
{
  public class PingControllersTests
  {
    [Fact]
    public void Get_ReturnsPong()
    {
      var sut = new PingController();

      var returned = sut.Get();

      Assert.Equal("Pong!", returned);
    }
  }
}
