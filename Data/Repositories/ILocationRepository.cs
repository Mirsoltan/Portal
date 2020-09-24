using System.Collections.Generic;
using ViewModels.Location;

namespace Data.Repositories
{
    public interface ILocationRepository
    {
        void BindSubCategories(TreeViewLocation loc);
        List<TreeViewLocation> GetLocations();
    }
}