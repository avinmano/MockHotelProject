using MockHotelProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Interfaces
{
    public interface IRulesRepository
    {
        Task<List<Rules>> Select(int id, int idAccomodation, int percentage);

        Task<Rules> InsertNewRule(Rules rule);

        Task<Rules> UpdateRule(Rules rule);

        Task<int> DeleteRule(int id);
    }
}
