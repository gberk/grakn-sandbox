using ConversationalAssitant.Core.Services.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConversationalAssistant.Infrastructure.Services.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUtilityServices(this IServiceCollection services)
        {
            services.AddScoped<INoteTakingService, NoteTakingService>();
            services.AddScoped<IUtlityServicesContainer, UtilityServicesContainer>();
            return services;
        }
    }
}
