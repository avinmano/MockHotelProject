using MediatR;
using Microsoft.Identity.Client;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.Mediator.RulesRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RulesHandler
{
    public class RulesSelectHandler : IRequestHandler<RulesSelectRequest, List<Rules>>
    {
        private readonly IRulesRepository _repository;

        public RulesSelectHandler(IRulesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Rules>>Handle(RulesSelectRequest request, CancellationToken cancellationToken)
        {
            return await _repository.Select(request._idRule, request._idAccomodation, request._percentage);
        }
    }
}
