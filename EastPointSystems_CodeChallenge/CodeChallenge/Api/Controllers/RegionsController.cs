using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CodeChallenge.Api.Controllers
{
    using CodeChallenge.Data.Interfaces;
    using CodeChallenge.Data.Repositories;
    using CodeChallenge.Entities;

    public class RegionsController : ApiController
    {
        public List<ZipcodeGroup> Get([FromBody] Region region)
        {
            var regionResult = new Region();
            var zipCodeList = new List<ZipcodeGroup>();
            try
            {
                regionResult = this.Repository().Get(region.Id);
            }
            catch (Exception exception)
            {
                //Region could not be retrieved.
                //Log Exception somewhere. Possibly determine some logic to return an action.
            }
            if (regionResult != null)
            {
                zipCodeList = regionResult.Zipcodes;
            }
            return zipCodeList;
        }

        public HttpResponseMessage Post([FromBody] Region region)
        {
            HttpResponseMessage response;
            try
            {
                Repository().Add(region);
                response = Request.CreateResponse(HttpStatusCode.OK, region);
            }
            catch (Exception exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, region);
            }
            return response;
        }

        public HttpResponseMessage Delete([FromBody] Region region)
        {
            HttpResponseMessage response;
            try
            {
                Repository().Remove(region.Id);
                response = Request.CreateResponse(HttpStatusCode.OK, "Region removed.");
            }
            catch (Exception exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to remove region.");
            }
            return response;
        }

        private IRegionRepository _repository;

        public IRegionRepository Repository()
        {
            return _repository ?? (_repository = new RegionRepository());
        }
    }
}
