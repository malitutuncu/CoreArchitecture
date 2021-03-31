using Core.CrossCuttings.Caching;
using Core.CrossCuttings.Caching.Microsoft;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class CoreRegistration
    {
        public static void AddBusinessConfiguration(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

        }
    }
}
