﻿using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
   public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
       AddRepositories(services);
        AddDbContext(services, config);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
        
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<CashFlowDbContext>(config => config.UseSqlServer(connectionString));
    }
}

