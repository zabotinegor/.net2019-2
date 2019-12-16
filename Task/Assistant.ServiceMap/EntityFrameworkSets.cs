using Assistant.Common;
using Assistant.DAL.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Assistant.ServiceMap
{
    internal static class EntityFrameworkSets
    {
        internal static void ConfigureEntityFramework(this IServiceCollection services)
        {
            //TODO : Add extention for AddDbContext
            //services.AddDbContext<AssistantContext>(options => options.UseSqlServer(Settings.ConnectionString));
        }
    }
}
