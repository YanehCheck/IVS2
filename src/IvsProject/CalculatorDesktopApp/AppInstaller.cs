using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorDesktopApp.Services;
using CalculatorDesktopApp.Services.Interfaces;
using CalculatorDesktopApp.ViewModels;
using CalculatorDesktopApp.Views;
using CommunityToolkit.Mvvm.Messaging;

namespace CalculatorDesktopApp
{
    public static class AppInstaller
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<AppShell>();
            services.AddSingleton<IMessenger>(_ => StrongReferenceMessenger.Default);
            services.AddSingleton<IMessengerService, MessengerService>();

            services.Scan(selector => selector
                .FromAssemblyOf<App>()
                .AddClasses(filter => filter.AssignableTo<ContentPageBase>())
                .AsSelf()
                .WithTransientLifetime());

            services.Scan(selector => selector
                .FromAssemblyOf<App>()
                .AddClasses(filter => filter.AssignableTo<IViewModel>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
