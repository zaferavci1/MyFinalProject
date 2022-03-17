﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //Çıplak class kalmasın
   public class Category: Abstract.IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
