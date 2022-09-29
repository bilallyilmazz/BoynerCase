﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductCategory:AuditableEntity
    {
        public string Name { get; set; }
        public int CategoryAttributes { get; set; }
    }
}
