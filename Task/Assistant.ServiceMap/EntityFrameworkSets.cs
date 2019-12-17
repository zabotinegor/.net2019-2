using Assistant.Common;
using Assistant.DAL.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assistant.ServiceMap
{
    internal static class EntityFrameworkSets
    {
        internal static void ConfigureEntityFramework(this IServiceCollection services)
        {
            services.AddDbContext<AssistantContext>(options => options.UseSqlServer(Settings.ConnectionString));
        }
    }
}
