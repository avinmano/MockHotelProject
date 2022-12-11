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
    public class AccomodationUpdateHandler : IRequestHandler<AccomodationUpdateRequest, Accomodations>
    {
        private readonly IAccomodationsRepository _repository;

        public AccomodationUpdateHandler(IAccomodationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Accomodations> Handle(AccomodationUpdateRequest request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAccomodation(request._accomodation);
        }
    }
}
