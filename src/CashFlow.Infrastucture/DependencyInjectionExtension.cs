﻿using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastucture.DataAccess;
using CashFlow.Infrastucture.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastucture
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
           AddDbContext(services, configuration);
           AddRepositories(services);
        }


        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IExpensesRepositorie, ExpensesRepository>();
        }


        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            var version = new Version(8, 0, 40);
            var serverVersion = new MySqlServerVersion(version);

            //optionsBuilder.UseMySql(connectionString, serverVersion);


            services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString,serverVersion));
        }
    }
}
