using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }
       
        public int AccomodationId { get; set; }
        
        public string RoomTypeDesc { get; set; }

        public int? Heirarchy { get; set; }

    }
}
