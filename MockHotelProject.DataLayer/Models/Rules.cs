using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Models
{
    public class Rules
    {
        [Key]
        public int Id { get; set; }
        public int idAccomodation { get; set; }

        public int IdRoomType { get; set; }

        public string Type { get; set; }

        public int Percentage { get; set; }

        public int RuleDescription { get; set; }
    }
}
