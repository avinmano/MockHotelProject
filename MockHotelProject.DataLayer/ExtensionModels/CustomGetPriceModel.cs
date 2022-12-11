using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.ExtensionModels
{
    public class CustomGetPriceModel
    {
        public int AccomodationId { get; set; }

        public string AccomodationName { get; set; }
        
        public string RoomTypeDesc { get; set; }
        
        public decimal? Price { get; set; }
    }
}
