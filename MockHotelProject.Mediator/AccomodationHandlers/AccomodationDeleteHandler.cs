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
    public class AccomodationDeleteHandler : IRequestHandler<AccomodationDeleteRequest, int>
    {
        private readonly IAccomodationsRepository _repository;

        public AccomodationDeleteHandler(IAccomodationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AccomodationDeleteRequest request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAccomodation(request._idAccomodation);
        }
    }
}
