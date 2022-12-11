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
    public class RoomTypeSelectHandler : IRequestHandler<RoomTypeSelectRequest, List<RoomType>>
    {
        private IRoomTypeRepository _repository;

        public RoomTypeSelectHandler(IRoomTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoomType>> Handle(RoomTypeSelectRequest request, CancellationToken cancellationToken)
        {
            return await _repository.Select(request._parameters);
        }
    }
}
