﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries
{
    public class GetProductByNameQuery:IRequest<GetProductViewModel>
    {
        public string Name { get; set; }
    }
}