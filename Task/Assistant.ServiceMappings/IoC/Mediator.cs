using Assistant.BLL.Core.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Assistant.ServiceMappings.IoC
{
    internal static class Mediator
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(BaseHandler));
        }
    }
}
