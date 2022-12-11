using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.QueryObjects
{
    public class PriceListQueryParameters
    {
        public int Id { get; set; }

        public int IdRoomType { get; set; }

        public decimal Price { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }



    }
}
