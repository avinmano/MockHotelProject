using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<List<RoomType>> Select(RoomTypeQueryParameters parameters);

        Task<RoomType> AddRoomType(RoomType roomType);

        Task<RoomType> UpdateRoomType(RoomType roomType);

        Task<int> DeleteRoomType(int id);
    }
}
