using MediatR;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.AccomodationRequest
{
    public class AccomodationDeleteRequest : IRequest<int>
    {
        public int _idAccomodation;

        public AccomodationDeleteRequest(int idAccomodation)
        {
            this._idAccomodation = idAccomodation;
        }
    }
}
