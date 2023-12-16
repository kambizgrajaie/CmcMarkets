using CmcMarkets.Backend.Core.Abstractions.Persistence.Queries;
using CmcMarkets.Backend.Persistence.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CmcMarkets.Backend.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppQueries(this IServiceCollection services) =>
            services.AddScoped<IUserTaskQueries, UserTaskQueries>();
    }
}
