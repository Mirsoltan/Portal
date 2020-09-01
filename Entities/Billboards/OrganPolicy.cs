using Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Billboards
{
    public class OrganPolicy : GenericBaseEntities<int>
    {
        public string Title { get; set; }
    }
}
