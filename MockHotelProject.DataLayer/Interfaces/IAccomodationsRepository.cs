using MockHotelProject.DataLayer.Models;
using MockHotelProject.DataLayer.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.Interfaces
{
    public interface IAccomodationsRepository
    {
        Task<List<Accomodations>> SelectMethod(AccomodationQueryParameters queryObj);

        Task<Accomodations> InsertNewAccomodation(Accomodations accomodation);

        Task<Accomodations> UpdateAccomodation(Accomodations accomodation);

        Task<int> DeleteAccomodation(int id);

    }
}
