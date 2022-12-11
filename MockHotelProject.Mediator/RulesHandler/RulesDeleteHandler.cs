using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.Mediator.RulesRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RulesHandler
{
    public class RulesDeleteHandler : IRequestHandler<RulesDeleteRequest, int >
    {
        private readonly IRulesRepository _repository;

        public RulesDeleteHandler(IRulesRepository repository)
        {
            _repository = repository;
        }

        public async Task<int>Handle(RulesDeleteRequest request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteRule(request._idRule);
        }
    }
}
