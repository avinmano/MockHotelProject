using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Models
{
    public class Rules
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Accomodation")]
        public int IdAccomodation { get; set; }

        public int Percentage { get; set; }
    }
}
