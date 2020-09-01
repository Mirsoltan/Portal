using Data.UnitOfWork;
using Entities.LocationsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels.Location;

namespace Data.Repositories
{
    public class LocationRepository
    {
        //private readonly PortalDbContext _context;
        private readonly IUnitOfWork _uw;
        public LocationRepository(IUnitOfWork uw)
        {
            //_context = context;
            _uw = uw;
        }

        public void BindSubCategories(TreeViewLocation loc)
        {
            //var SubCategories = (from c in _context.Locationss
            //                     where (c.ParentLocationID == loc.locationId)
            //                     select new TreeViewCategory { CategoryID = c.CategoryID, CategoryName = c.CategoryName }).ToList();
            var subLocation =  _uw.BaseRepository<Location>()
                .FindByConditionAsync(w => w.ParentLocationID == loc.LocationID)
                .Result.Select(select=> new TreeViewLocation 
                { LocationID = select.LocationID , LocationName= select.LocationName  });
            foreach (var item in subLocation)
            {
                BindSubCategories(item);
                loc.SubLocations.Add(item);
            }
        }
    }
}