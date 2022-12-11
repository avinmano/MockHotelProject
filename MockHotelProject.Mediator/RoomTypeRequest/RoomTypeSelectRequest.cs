using MediatR;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RoomTypeRequest
{
    public class RoomTypeSelectRequest : IRequest<List<RoomType>>
    {
        public RoomTypeQueryParameters _parameters;

        public RoomTypeSelectRequest(RoomTypeQueryParameters parameters)
        {
            _parameters = parameters;
        }
    }
}
