using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RulesRequest
{
    public class RulesInsertRequest : IRequest<Rules>
    {
        public Rules _rules;

        public RulesInsertRequest(Rules rules)
        {
            _rules = rules;
        }
    }
}
