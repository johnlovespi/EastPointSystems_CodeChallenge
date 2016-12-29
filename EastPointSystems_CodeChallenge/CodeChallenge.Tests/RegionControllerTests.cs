using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using CodeChallenge.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge.Tests
{
    using CodeChallenge.Api.Controllers;
    using CodeChallenge.Entities;
    using Xunit;

    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    /// <summary>
    /// Summary description for RegionControllerTests
    /// </summary>
    [TestClass]
    public class RegionControllerTests
    {
        private RegionsController _rc;

        public RegionsController Rc()
        {
            if (_rc == null)
            {
                _rc = new RegionsController();
            }
            return _rc;

        }

        public void InitalizeController()
        {
            this.Rc().Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };
        }

        [Fact]
        public void Get_ReturnZipCodes()
        {
            var region = CreateTestRegion();
            InitalizeController();

            this.Rc().Repository().Add(region);
            var zipCodes = this.Rc().Get(region);
            Assert.IsTrue(zipCodes != null);
        }

        [Fact]
        public void Create_Region()
        {
            var region = CreateTestRegion();
            InitalizeController();

            var status  = this.Rc().Post(region);
            var result = Rc().Repository().Get(region.Id);
            Assert.AreEqual(region, result);
            Assert.AreEqual(status.StatusCode, HttpStatusCode.OK);
        }

        [Fact]
        public void Remove_Region()
        {
            var region = CreateTestRegion();
            InitalizeController();
            this.Rc().Repository().Add(region);

            Rc().Delete(region);
            var gets = this.Rc().Repository().Get(region.Id);
            Assert.IsTrue(gets == null);
        }

        public Region CreateTestRegion()
        {
            var region = new Region();
            var identityCheck = new Guid();
            region.Id = identityCheck;
            region.Name = "TestName";
            var listOfZips = new List<ZipcodeGroup>();
            var zipCodeGroup = new ZipcodeGroup
            {
                Start = "34711",
                End = "34711"
            };
            listOfZips.Add(zipCodeGroup);
            region.Zipcodes = listOfZips;
            return region;
        }
    }
}
