using Entities.LocationsEntities;
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
        public int? ParentLocationID { get; set; }
        public string LocationName { get; set; }
        public List<TreeViewLocation> SubLocations { get; set; }

        public BaseLocationType? baseLocationType { get; set; }
        public SecondaryLocationType? SecondaryLocationType { get; set; }
    }
    /// <summary>
    /// نمایش لیست مکانها به صورت درختی در دراپ دان لیست
    /// ComboTree Plugins
    /// </summary>
    public class TreeViewLocationComboTree
    {
        public TreeViewLocationComboTree()
        {
            subs = new List<TreeViewLocationComboTree>();
        }
        public int id { get; set; }
        public string title { get; set; }
        public List<TreeViewLocationComboTree> subs { get; set; }
    }
}
