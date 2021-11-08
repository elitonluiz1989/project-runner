using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProjectRunner.WPF.Tools
{
    public static class ServiceProviderAccessor
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
