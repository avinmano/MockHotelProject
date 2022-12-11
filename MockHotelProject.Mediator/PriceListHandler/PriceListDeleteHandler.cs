using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.Mediator.PriceListRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.PriceListHandler
{
    public class PriceListDeleteHandler : IRequestHandler<PriceListDeleteRequest, int>
    {
        private readonly IPriceListRepository _repository;

        public PriceListDeleteHandler(IPriceListRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(PriceListDeleteRequest request, CancellationToken cancellationToken)
        {
            return await _repository.DeletePrice(request.Id);
        }
    }
}
