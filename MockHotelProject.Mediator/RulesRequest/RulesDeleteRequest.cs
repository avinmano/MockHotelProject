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
    public  class RulesDeleteRequest : IRequest<int>
    {
        public int _idRule;

        public RulesDeleteRequest(int idRule)
        {
            _idRule = idRule;
        }
    }
}
