using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.RulesRequest
{
    public class RulesSelectRequest : IRequest<List<Rules>>
    {
        public int _idRule;
        public int _idAccomodation;
        public int _percentage;


        public RulesSelectRequest(int idRule, int idAccomodation, int percentage)
        {
            _idRule = idRule;
            _idAccomodation = idAccomodation;
            _percentage = percentage;
        }
    }
}
