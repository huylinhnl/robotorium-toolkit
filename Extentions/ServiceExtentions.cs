using RoboToolkit.Builders;
using RoboToolkit.Services;

namespace RoboToolkit.Extentions;
internal static class ServiceExtentions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection services)
    {
        services.AddTransient<IRequestMessageBuilder, RequestMessageBuilder>();
        services.AddTransient<IRequestMessageService, RequestMessageService>();

        return services;
    }
}

