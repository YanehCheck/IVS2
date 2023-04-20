using CalculatorDesktopApp.Views;
using Microsoft.Extensions.Logging;

namespace CalculatorDesktopApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Jua-Regular.ttf", "Jua");
                });
            builder.Services
                .AddAppServices();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            Routing.RegisterRoute("settings", typeof(SettingsView));
            Routing.RegisterRoute("help", typeof(HelpView));

            return app;
        }
    }
}