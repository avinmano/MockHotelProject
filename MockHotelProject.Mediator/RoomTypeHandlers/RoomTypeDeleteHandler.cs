using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.Mediator.RoomTypeRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RoomTypeHandlers
{
    public class RoomTypeDeleteHandler : IRequestHandler<RoomTypeDeleteRequest, int>
    {
        private readonly IRoomTypeRepository _repository;

        public RoomTypeDeleteHandler(IRoomTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(RoomTypeDeleteRequest request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteRoomType(request._idRoomType);
        }
    }
}
