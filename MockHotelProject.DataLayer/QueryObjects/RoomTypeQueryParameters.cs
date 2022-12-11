using Azure.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.QueryObjects
{
    public class RoomTypeQueryParameters
    {
        public int Id { get; set; }

        public string RoomTypeDesc { get; set; }

        public int IdAccomodation { get; set; }

        public int Heirarchy { get; set; }
    }
}
