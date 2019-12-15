using Microsoft.Extensions.DependencyInjection;

namespace Assistant.ServiceMap
{
    public static class IoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.ConfigureEntityFramework();
            services.ConfigureMediator();
        }
    }
}
