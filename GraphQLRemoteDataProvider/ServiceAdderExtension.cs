using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDataClient
{
    public  static class ServiceAdderExtension
    {
        /// <summary>
        /// Registers Required Services and configurations for IGQLDataClient 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="options"></param>
        public static void AddGQLDataClient(this IServiceCollection service, Action<GQLConfig> options)
        {
            service.Configure<GQLConfig>(options);
            service.AddScoped<IGQLDataClient, GQLDataClient>();
        }
    }
}
