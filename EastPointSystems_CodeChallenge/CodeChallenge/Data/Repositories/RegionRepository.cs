using CodeChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeChallenge.Entities;

namespace CodeChallenge.Data.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private Dictionary<Guid, Region> regions;

        public RegionRepository()
        {
            this.regions = new Dictionary<Guid, Region>();
        }

        public void Add(Region region)
        {
            if (regions.ContainsKey(region.Id)) regions[region.Id] = region;
            else regions.Add(region.Id, region);
        }

        public Region Get(Guid regionId)
        {
            Region region = null;
            regions.TryGetValue(regionId, out region);

            return region;
        }

        public void Remove(Guid regionId)
        {
            if (!regions.ContainsKey(regionId))
                throw new InvalidOperationException(string.Format("Region #{0} does not exist.", regionId));

            regions.Remove(regionId);
        }
    }
}