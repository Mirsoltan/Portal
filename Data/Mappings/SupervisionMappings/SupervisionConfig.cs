using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings.SupervisionMappings
{
    public static class SupervisionConfig
    {
        public static void ApplySupervisionConfig (this ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new SupervisionMapping());
        }
    }
}
