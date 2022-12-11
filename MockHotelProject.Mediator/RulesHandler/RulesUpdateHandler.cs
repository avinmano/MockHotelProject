using MediatR;
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
    public class RulesUpdateHandler : IRequestHandler<RulesUpdateRequest, Rules>
    {
        private readonly IRulesRepository _repository;

        public RulesUpdateHandler(IRulesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Rules> Handle(RulesUpdateRequest request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateRule(request._rules);
        }
    }
}
