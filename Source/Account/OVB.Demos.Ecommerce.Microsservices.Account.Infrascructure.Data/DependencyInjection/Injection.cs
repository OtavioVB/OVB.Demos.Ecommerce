﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbInfrascructureConfiguration(this IServiceCollection serviceCollection, 
        string postgreeSqlConnection, string migrationsAssembly)
    {
        serviceCollection.AddDbContextPool<DataContext>(p => p.UseNpgsql(postgreeSqlConnection, 
            p => p.MigrationsAssembly(migrationsAssembly)), 20);

        serviceCollection.AddScoped<IBaseRepository<AccountDataTransfer>, AccountRepository>();
        serviceCollection.AddScoped<BaseRepository<AccountDataTransfer>, AccountRepository>();

        return serviceCollection;
    }
}
