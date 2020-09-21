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

        /// <summary>
        /// لیست زیر مجموعه مکانها را به سرشاخه میچسباند
        /// </summary>
        /// <param name="loc"></param>
        public void BindSubCategories(TreeViewLocation loc)
        {
            //var SubCategories = (from c in _context.Locationss
            //                     where (c.ParentLocationID == loc.locationId)
            //                     select new TreeViewCategory { CategoryID = c.CategoryID, CategoryName = c.CategoryName }).ToList();
            var subLocation = _uw.BaseRepository<Locations>()
                .FindByConditionAsync(w => w.ParentLocationID == loc.LocationID)
                .Result.Select(select => new TreeViewLocation
                {
                    LocationID = select.LocationID,
                    LocationName = select.LocationName,
                    ParentLocationID = select.ParentLocationID,
                    baseLocationType = select.baseLocationType,
                    SecondaryLocationType = select.SecondaryLocationType
                });

            foreach (var item in subLocation)
            {
                BindSubCategories(item);
                loc.SubLocations.Add(item);
            }
        }

        /// <summary>
        /// لیست مکانها را با زیر مجموعه هایشان برمیگرداند
        /// </summary>
        /// <returns></returns>
        public List<TreeViewLocation> GetLocations()
        {
            var sLocation = _uw.BaseRepository<Locations>()
                .FindByConditionAsync(w => w.ParentLocationID == null)
                .Result.Select(select => new TreeViewLocation
                { LocationID = select.LocationID, LocationName = select.LocationName,
                baseLocationType = select.baseLocationType , SecondaryLocationType = select.SecondaryLocationType
                }).ToList();


            foreach (var item in sLocation)
            {
                BindSubCategories(item);
            }
            return sLocation;
        }

        /// <summary>
        /// لیست مکانها را با زیر مجموعه هایشان برمیگرداند
        /// </summary>
        /// <param name="locationid"></param>
        /// <returns></returns>
        public List<TreeViewLocation> GetLocations(int? locationid)
        {
            var sLocation = _uw.BaseRepository<Locations>()
                .FindByConditionAsync(w => w.ParentLocationID == locationid)
                .Result.Select(select => new TreeViewLocation
                { LocationID = select.LocationID, LocationName = select.LocationName }).ToList();


            foreach (var item in sLocation)
            {
                BindSubCategories(item);
            }
            return sLocation;
        }


        /// <summary>
        /// BindLocation
        /// برای ComboTree
        /// </summary>
        /// <param name="loc"></param>
        public void BindSubCategories(TreeViewLocationComboTree loc)
        {
            //var SubCategories = (from c in _context.Locationss
            //                     where (c.ParentLocationID == loc.locationId)
            //                     select new TreeViewCategory { CategoryID = c.CategoryID, CategoryName = c.CategoryName }).ToList();
            var subLocation = _uw.BaseRepository<Locations>()
                .FindByConditionAsync(w => w.ParentLocationID == loc.id)
                .Result.Select(select => new TreeViewLocationComboTree
                { id = select.LocationID, title = select.LocationName });
            foreach (var item in subLocation)
            {
                BindSubCategories(item);
                loc.subs.Add(item);
            }
        }
        public List<TreeViewLocationComboTree> GetLocations(bool comboTree)
        {
            var sLocation = _uw.BaseRepository<Locations>()
                .FindByConditionAsync(w => w.ParentLocationID == null)
                .Result.Select(select => new TreeViewLocationComboTree
                { id = select.LocationID, title = select.LocationName }).ToList();


            foreach (var item in sLocation)
            {
                BindSubCategories(item);
            }
            return sLocation;
        }


    }
}