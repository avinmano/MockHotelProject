using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;

namespace MockHotelProject.DataLayer.Interfaces
{
    public interface IPriceListRepository
    {
        Task<int> DeletePrice(int id);
        Task<PriceList> InsertPrice(PriceList price);
        Task<List<PriceList>> Select(PriceListQueryParameters parameters);
        Task<PriceList> UpdatePrice(PriceList price);
    }
}