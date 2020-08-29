using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.BaseEntities
{
    public class GenericBaseEntities<T>
    {
        public T Id { get; set; }
    }
}
