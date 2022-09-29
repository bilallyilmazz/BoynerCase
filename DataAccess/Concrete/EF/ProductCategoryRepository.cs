﻿using Core.DataAccess.EF;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class ProductCategoryRepository : EfRepository<ProductCategory, BoynerCaseContext>, IProductCategoryRepository
    {
    }
}
