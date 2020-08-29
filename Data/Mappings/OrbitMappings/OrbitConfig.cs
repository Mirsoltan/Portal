using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings.OrbitMappings
{
    public static class OrbitConfig
    {
        public static void ApplyOrbitConfig(this ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new OrbitMapping());
        }
    }
}
