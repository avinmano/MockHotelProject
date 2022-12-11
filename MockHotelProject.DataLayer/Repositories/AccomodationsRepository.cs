using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Repositories
{
    public class AccomodationsRepository : IAccomodationsRepository
    {
        private readonly DatabaseContext _database;

        public AccomodationsRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<List<Accomodations>> SelectMethod(AccomodationQueryParameters queryObj)
        {
            IQueryable<Accomodations> query = _database.Set<Accomodations>();

            if (queryObj.Id != 0)
                query = query.Where(x => x.Id == queryObj.Id);
            if (!queryObj.Country.IsNullOrEmpty())
                query = query.Where(x => x.Country.Equals(queryObj.Country));
            if (!queryObj.Address.IsNullOrEmpty())
                query = query.Where(x => x.Address.Equals(queryObj.Address));
            if (!queryObj.Name.IsNullOrEmpty())
                query = query.Where(x => x.Name.Equals(queryObj.Name));
            if (!queryObj.NameLike.IsNullOrEmpty())
                query = query.Where(x => x.Name.Contains(queryObj.NameLike));
            if (!queryObj.City.IsNullOrEmpty())
                query = query.Where(x => x.City.Equals(queryObj.City));

            return await query.ToListAsync();
        }

        public async Task<Accomodations> InsertNewAccomodation(Accomodations accomodation)
        {
            await _database.Accomodations.AddAsync(accomodation);
            await _database.SaveChangesAsync();
            return accomodation;
        }

        public async Task<Accomodations> UpdateAccomodation(Accomodations accomodation)
        {
            _database.Entry(accomodation).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return accomodation;
        }

        public async Task<int> DeleteAccomodation(int id)
        {
            Accomodations item = await _database.Set<Accomodations>().FindAsync(id);
            if (item != null)
            {
                _database.Accomodations.Remove(item);
                return await _database.SaveChangesAsync();
            }
            return -1;
        }
    }
}
