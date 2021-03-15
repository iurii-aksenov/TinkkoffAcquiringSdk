using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TinkkoffAcquiringSdk.Extensions
{
    public static class AddTinkoffAcquiringExtension
    {
        private const string SectionName = "Acquiring";

        public static IServiceCollection AddTinkoffAcquiring(this IServiceCollection services, string sectionName = SectionName)
        {
            if (services is null)
            {
                throw new ArgumentNullException($"{nameof(AddTinkoffAcquiring)}: {nameof(services)} is null.");
            }

            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var filesOptions = (configuration ?? throw new NullReferenceException("IConfiguration is null"))
                .GetOptions<AcquiringOptions>(sectionName);
            services.AddSingleton(filesOptions);
            services.AddSingleton<AcquiringClient>();
            return services;
        }
    }
}