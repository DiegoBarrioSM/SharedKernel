﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application.Caching;
using SharedKernel.Application.Serializers;
using SharedKernel.Infrastructure.Serializers;

namespace SharedKernel.Infrastructure.Caching
{
    public static class DistributedCacheServiceExtensions
    {
        public static IServiceCollection AddRedisDistributedCache(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHealthChecks()
                .AddRedis(GetRedisConfiguration(configuration), "Redis Cache", tags: new[] { "Cache", "Redis" });

            return services
                .AddStackExchangeRedisCache(opt =>
                {
                    opt.Configuration = GetRedisConfiguration(configuration);
                })
                .AddTransient<IBinarySerializer, BinarySerializer>()
                .AddTransient<ICacheHelper, DistributedCacheHelper>();
        }

        private static string GetRedisConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection("RedisCacheOptions:Configuration").Value;
        }
    }
}
