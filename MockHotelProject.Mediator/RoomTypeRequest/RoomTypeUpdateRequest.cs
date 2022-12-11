using MediatR;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RoomTypeRequest
{
    public class RoomTypeUpdateRequest : IRequest<RoomType>
    {
        public RoomType _roomType;

        public RoomTypeUpdateRequest(RoomType roomType)
        {
            _roomType = roomType;
        }
    }
}
