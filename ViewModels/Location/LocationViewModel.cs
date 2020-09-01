using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Location
{
    public class TreeViewLocation
    {
        public TreeViewLocation()
        {
            SubLocations = new List<TreeViewLocation>();
        }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public List<TreeViewLocation> SubLocations { get; set; }
    }
}
