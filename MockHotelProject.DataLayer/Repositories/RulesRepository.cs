using Microsoft.EntityFrameworkCore;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Repositories
{
    public class RulesRepository : IRulesRepository
    {
        private readonly DatabaseContext _database;

        public RulesRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<List<Rules>> Select(int id, int idAccomodation, int percentage)
        {
            IQueryable<Rules> rulesQuery = _database.Set<Rules>();

            if(id > 0)
                rulesQuery = rulesQuery.Where(x => x.Id == id);
            if(idAccomodation > 0)
                rulesQuery = rulesQuery.Where(x => x.IdAccomodation == idAccomodation);
            if(percentage > 0)
                rulesQuery = rulesQuery.Where(x => x.Percentage == percentage);
            return await rulesQuery.ToListAsync();
        }

        public async Task<Rules> InsertNewRule(Rules rule)
        {
            await _database.Rules.AddAsync(rule);
            await _database.SaveChangesAsync();
            return rule;
        }

        public async Task<Rules> UpdateRule(Rules rule)
        {
            _database.Entry(rule).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return rule;
        }

        public async Task<int> DeleteRule(int id)
        {
            Rules item = await _database.Rules.FindAsync(id);
            if(item != null)
            {
                _database.Rules.Remove(item);
                await _database.SaveChangesAsync();
                return item.Id; 
            }
            return -1   ;
        }
    }
}
