using MediatR;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.PriceListRequest
{
    public record PriceListUpdateRequest(PriceList Price) : IRequest<PriceList>;
}
