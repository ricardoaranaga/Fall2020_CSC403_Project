﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project.code
{
    public abstract class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfItems { get; set; }
        public Item()
        {
        }

        public abstract int Use();
        
    }
}
