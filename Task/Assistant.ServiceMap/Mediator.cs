using Assistant.BLL.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Assistant.ServiceMap
{
    internal static class Mediator
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(BaseHandler));
        }
    }
}
