using Microsoft.AspNetCore.Mvc;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.QueryObjects
{
    public class AccomodationQueryParameters
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameLike { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}
