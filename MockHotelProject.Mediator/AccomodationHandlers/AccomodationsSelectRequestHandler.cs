using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.Mediator.AccomodationRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.AccomodationHandlers
{
    public class AccomodationsSelectRequestHandler : IRequestHandler<AccomodationSelectRequest, List<Accomodations>>
    {
        private readonly IAccomodationsRepository _repository;

        public AccomodationsSelectRequestHandler(IAccomodationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Accomodations>> Handle(AccomodationSelectRequest request, CancellationToken cancellationToken)
        {
            return await _repository.SelectMethod(request._queryParameters);
        }
    }
}
