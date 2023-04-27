﻿using HahnEmployeesAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnEmployeesAPI.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
