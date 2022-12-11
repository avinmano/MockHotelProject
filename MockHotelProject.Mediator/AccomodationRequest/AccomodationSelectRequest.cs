using MediatR;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.AccomodationRequest
{
    public class AccomodationSelectRequest : IRequest<List<Accomodations>>
    {
        public AccomodationQueryParameters _queryParameters;

        public AccomodationSelectRequest(AccomodationQueryParameters queryParameters)
        {
            _queryParameters = queryParameters;
        }
    }
}
