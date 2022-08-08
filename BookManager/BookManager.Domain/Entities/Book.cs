﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    public class Book : Key
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
