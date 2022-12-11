using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly DatabaseContext _database;

        public RoomTypeRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<List<RoomType>>Select(RoomTypeQueryParameters parameters )
        {
            IQueryable<RoomType> query = _database.Set<RoomType>();
            if(parameters.Id > 0)
                query = query.Where(x => x.Id == parameters.Id);
            if(!parameters.RoomTypeDesc.IsNullOrEmpty())
                query = query.Where(x => x.RoomTypeDesc == parameters.RoomTypeDesc);
            if (parameters.IdAccomodation > 0)
                query = query.Where(x => x.AccomodationId == parameters.IdAccomodation);
            if (parameters.Heirarchy > 0)
                query = query.Where(x => x.Heirarchy == parameters.Heirarchy);

            return await query.ToListAsync();
        }

        public async Task<RoomType> AddRoomType(RoomType roomType)
        {
            await _database.RoomTypes.AddAsync(roomType);
            await _database.SaveChangesAsync();
            return roomType;
        }

        public async Task<RoomType> UpdateRoomType(RoomType roomType)
        {
            _database.Entry(roomType).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return roomType;
        }

        public async Task<int> DeleteRoomType(int id)
        {
            var deleteItem = await _database.RoomTypes.FindAsync(id);
            if(deleteItem != null)
            {
                _database.RoomTypes.Remove(deleteItem);
                return await _database.SaveChangesAsync();
            }
            return -1;
        }
    }
}
