using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RoomTypeRequest
{
    public class RoomTypeDeleteRequest : IRequest<int>
    {
        public int _idRoomType;

        public RoomTypeDeleteRequest(int idRoomType)
        {
            _idRoomType = idRoomType;
        }
    }
}
