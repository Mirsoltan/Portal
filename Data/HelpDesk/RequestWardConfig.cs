using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.HelpDesk
{
    public static class RequestWardConfig

    {
        public static void ApplyRequestWardConfig(this ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new RequestWardMapping());

        }
    }
}
