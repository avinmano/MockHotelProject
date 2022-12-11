using MediatR;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.AccomodationRequest 
{ 
    public class AccomodationInsertRequest : IRequest<Accomodations>
    {
        public Accomodations accomodation;

        public AccomodationInsertRequest(Accomodations accomodation)
        {
            this.accomodation = accomodation;
        }
    }
}
