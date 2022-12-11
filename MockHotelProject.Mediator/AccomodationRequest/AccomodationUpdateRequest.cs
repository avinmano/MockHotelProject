using MediatR;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.AccomodationRequest 
{ 
    public class AccomodationUpdateRequest : IRequest<Accomodations>
    {
        public Accomodations _accomodation;

        public AccomodationUpdateRequest(Accomodations accomodation)
        {
            _accomodation = accomodation;
        }
    }
}
