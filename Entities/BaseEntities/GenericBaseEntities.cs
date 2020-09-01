using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.BaseEntities
{
    public class GenericBaseEntities<T> : BaseEntity
    {
        [Display(Name = "شناسه")]
        public T Id { get; set; }

    }
}
