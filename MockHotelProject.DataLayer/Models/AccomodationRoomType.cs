using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Models
{
    public class AccomodationRoomType
    {
        [Key]
        public int Id { get; set; }
        public int AccomodationId { get; set; }
        public int RoomTypeId { get; set; }

        public virtual Accomodations Accomodation { get; set; }

        public virtual RoomType RoomType { get; set; }

        public int? Hierarchy { get; set; }

        public int MaxAvailability { get; set; }

        public decimal Price { get; set; }

    }
}
