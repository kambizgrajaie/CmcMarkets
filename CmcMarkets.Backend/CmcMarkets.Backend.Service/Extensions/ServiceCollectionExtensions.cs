using CmcMarkets.Backend.Core.Abstractions.Services.Tasks;
using CmcMarkets.Backend.Service.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CmcMarkets.Backend.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServicess(this IServiceCollection services) =>
            services.AddScoped<IUserTaskServices, UserTaskServices>();
    }
}
