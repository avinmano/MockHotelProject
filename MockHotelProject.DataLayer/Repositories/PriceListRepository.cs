using Microsoft.EntityFrameworkCore;
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
    public class PriceListRepository : IPriceListRepository
    {
        private readonly DatabaseContext _database;

        public PriceListRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<List<PriceList>> Select(PriceListQueryParameters parameters)
        {
            IQueryable<PriceList> query = _database.Set<PriceList>();
            if (parameters.Id > 0)
                query = query.Where(x => x.Id == parameters.Id);
            if (parameters.IdRoomType > 0)
                query = query.Where(x => x.IdRoomType == parameters.IdRoomType);
            if (parameters.Price > 0)
                query = query.Where(x => x.Price == parameters.Price);
            if (parameters.MinPrice > 0)
                query = query.Where(x => x.Price >= parameters.MinPrice);
            if (parameters.MaxPrice > 0)
                query = query.Where(x => x.Price <= parameters.MaxPrice);


            return await query.ToListAsync();
        }


        public async Task<PriceList> InsertPrice(PriceList price)
        {
            await _database.PriceList.AddAsync(price);
            await _database.SaveChangesAsync();
            return price;
        }

        public async Task<PriceList> UpdatePrice(PriceList price)
        {
            _database.Entry(price).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return price;
        }

        public async Task<int> DeletePrice(int id)
        {
            var deleteItem = await _database.PriceList.FindAsync(id);
            if (deleteItem != null)
            {
                _database.PriceList.Remove(deleteItem);
                return await _database.SaveChangesAsync();
            }
            return -1;
        }
    }
}
