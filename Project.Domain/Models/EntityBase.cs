﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
