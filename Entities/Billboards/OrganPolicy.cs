using Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Billboards
{
    public class OrganPolicy : BaseEntities<int>
    {
        public string Title { get; set; }
    }
}
