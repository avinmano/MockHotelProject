using MediatR;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using MockHotelProject.DataLayer.Repositories;
using MockHotelProject.Mediator.PriceListRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.Mediator.PriceListHandler
{
    public class PriceListUpdateHandler : IRequestHandler<PriceListUpdateRequest, PriceList>
    {
        private readonly IPriceListRepository _repository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRulesRepository _rulesRepository;
        public PriceListUpdateHandler(IPriceListRepository repository,
            IRoomTypeRepository roomTypeRepository,
            IRulesRepository rulesRepository)
        {
            _repository = repository;
            _roomTypeRepository = roomTypeRepository;
            _rulesRepository = rulesRepository;
        }

        public async Task<PriceList> Handle(PriceListUpdateRequest request, CancellationToken cancellationToken)
        {
            var isPriceValid = await IsRuleValidated(request.Price);

            if (isPriceValid)
                return await _repository.UpdatePrice(request.Price);
            else
                return null;
        }

        private async Task<bool> IsRuleValidated(PriceList priceListObj)
        {
            var roomType = (await _roomTypeRepository.Select(new RoomTypeQueryParameters { Id = priceListObj.IdRoomType })).First();
            var rule = (await _rulesRepository.Select(0, roomType.AccomodationId, 0)).FirstOrDefault();
            if (rule is not null)
            {
                if (roomType.Heirarchy.HasValue)
                {
                    var roomTypeParent = (await _roomTypeRepository.Select(new RoomTypeQueryParameters { Id = roomType.Heirarchy.Value })).First();

                    var parentRoomPrice = (await _repository.Select(new PriceListQueryParameters { IdRoomType = roomTypeParent.Id })).First();


                    var calc = parentRoomPrice.Price - (parentRoomPrice.Price * rule.Percentage / 100);

                    if (priceListObj.Price > calc)
                        return false;
                }

                var roomTypeChild = (await _roomTypeRepository.Select(new RoomTypeQueryParameters { Heirarchy = roomType.Id })).FirstOrDefault();
                if (roomTypeChild is not null)
                {
                    var childRoomPrice = (await _repository.Select(new PriceListQueryParameters { IdRoomType = roomTypeChild.Id }));

                    var calc = priceListObj.Price - (priceListObj.Price * rule.Percentage/100) ;
                    if (childRoomPrice.Any(x => x.Price > calc))
                        return false;
                }

            }
            return true;
        }
    }
}
