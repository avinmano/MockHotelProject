using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MockHotelProject.DataLayer.Interfaces;
using MockHotelProject.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHotelProject.DataLayer.DependencyInjection
{
    public static class DataLayerDependencyInjection
    {
        public static IServiceCollection RegisterDataLayerDependencies(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddTransient<IAccomodationsRepository, AccomodationsRepository>();
            service.AddTransient<IRoomTypeRepository, RoomTypeRepository>();
            service.AddTransient<IRulesRepository, RulesRepository>();
            service.AddTransient<IPriceListRepository, PriceListRepository>();

            return service;
        }
    }
}
