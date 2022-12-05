using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public int IdAccomodationRoomType { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public decimal Price { get; set; }
    }
}
