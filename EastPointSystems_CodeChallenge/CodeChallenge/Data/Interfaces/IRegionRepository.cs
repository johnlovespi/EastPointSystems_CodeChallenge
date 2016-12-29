using CodeChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Interfaces
{
    public interface IRegionRepository
    {
        Region Get( Guid regionId );

        void Add( Region region );

        void Remove( Guid regionId );
    }
}
