using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheMysteriousTower.Services;
using TheMysteriousTower.Services.Interfaces;

namespace TheMysteriousTower;

public static class Startup
{
    public static IServiceProvider? Services { get; private set; }

    public static void Init()
    {
        var host = Host.CreateDefaultBuilder()
                       .ConfigureServices(WireupServices)
                       .Build();
        Services = host.Services;
    }

    private static void WireupServices(IServiceCollection services)
    {
        services.AddWindowsFormsBlazorWebView();
        // How to add a singleton service:
        //services.AddSingleton<WeatherForecastService>();
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<IPlayerService, PlayerService>();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif
    }
}
