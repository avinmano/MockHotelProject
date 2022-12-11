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
    public class RoomTypeInsertHandler : IRequestHandler<RoomTypeInsertRequest, RoomType>
    {
        private readonly IRoomTypeRepository _repository;

        public RoomTypeInsertHandler(IRoomTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<RoomType> Handle(RoomTypeInsertRequest request, CancellationToken cancellationToken)
        {
            return await _repository.AddRoomType(request._accomodationRoomType);
        }
    }
}
