using Mawred_Task.Common;
using Mawred_Task.Repositories.Implementations;
using Mawred_Task.Repositories.Interfaces;
using Mawred_Task.Services.Implementations;
using Mawred_Task.Services.Interfaces;

namespace Mawred_Task.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            // Services
            services.AddScoped<ICandidateService, CandidateService>();

            // Common
            services.AddScoped<ResponseHandler>();

            return services;
        }
    }
}