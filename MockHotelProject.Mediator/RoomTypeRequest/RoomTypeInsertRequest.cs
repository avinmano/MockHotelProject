using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RoomTypeRequest
{
    public class RoomTypeInsertRequest : IRequest<RoomType>
    {
        public RoomType _accomodationRoomType;

        public RoomTypeInsertRequest(RoomType accomodationRoomType)
        {
            _accomodationRoomType = accomodationRoomType;
        }
    }
}
