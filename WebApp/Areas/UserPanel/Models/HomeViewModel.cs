using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Location;

namespace WebApp.Areas.UserPanel.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(IEnumerable<TreeViewLocation> viewLocation)
        {
            location = viewLocation;
        }
        public HomeViewModel()
        {
        }

        public IEnumerable<TreeViewLocation> location { get; set; }

        public int LocationID { get; set; }
        public int LocationName { get; set; }
        public int[] LocationId1 { get; set; }
    }
}
