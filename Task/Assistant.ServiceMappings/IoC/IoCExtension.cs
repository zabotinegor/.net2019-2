using Microsoft.Extensions.DependencyInjection;

namespace Assistant.ServiceMappings.IoC
{
    public static class IoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            //TODO : insert your own solution
            //services.ConfigureEntityFramework();
            services.ConfigureMediator();
        }
    }
}
