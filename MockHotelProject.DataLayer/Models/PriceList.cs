﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Models
{
    public class PriceList
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
