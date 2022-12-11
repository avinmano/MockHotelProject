using MediatR;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.PriceListRequest
{
    public record PriceListInsertRequest(PriceList Price) : IRequest<PriceList>;
}
