using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.PriceListRequest
{
    public record PriceListDeleteRequest(int Id) : IRequest<int>;
}
