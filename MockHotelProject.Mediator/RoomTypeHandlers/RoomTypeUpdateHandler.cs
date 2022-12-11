using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.Mediator.RoomTypeRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RoomTypeHandlers
{
    public class RoomTypeUpdateHandler : IRequestHandler<RoomTypeUpdateRequest, RoomType>
    {
        private readonly IRoomTypeRepository _repository;

        public RoomTypeUpdateHandler(IRoomTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<RoomType>Handle(RoomTypeUpdateRequest request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateRoomType(request._roomType);
        }
    }
}
