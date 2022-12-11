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
    public class PriceListSelectHandler : IRequestHandler<PriceListSelectRequest, List<PriceList>>
    {
        private readonly IPriceListRepository _repository;

        public PriceListSelectHandler(IPriceListRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PriceList>>Handle(PriceListSelectRequest request, CancellationToken cancellationToken)
        {
            return await _repository.Select(request.Parameters);
        }
    }
}
