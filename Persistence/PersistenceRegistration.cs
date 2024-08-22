using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        const string dbConnection = "server=localhost;port=8889;pooling=true;user=root;password=root;database=learn;sslMode=Preferred";

        services.AddDbContext<TableContext>(opt => opt.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection)));
        services.AddScoped<ITableSpecificationRepository, TableSpecificationRepository>();

        return services;
    }
}