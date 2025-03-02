using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RollAndRecord.Core;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using RollAndRecord.Core.Services.Repositories;
using RollAndRecord.Maui.NativeCore.Interfaces;
using RollAndRecord.Maui.NativeCore.Services;
using RollAndRecord.Maui.ViewModels;
using RollAndRecord.Maui.ViewModels.CustomerViewModels;
using RollAndRecord.Maui.ViewModels.SaleTypeViewModels;
using RollAndRecord.Maui.ViewModels.SaleViewModels;
using RollAndRecord.Maui.Views;
using RollAndRecord.Maui.Views.CustomerViews;
using RollAndRecord.Maui.Views.SalePages;
using RollAndRecord.Maui.Views.SaleTypeViews;
using SQLite;
namespace RollAndRecord.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .SetupSqlite()
                .SetupNativeCore()
                .SetupPages()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder SetupSqlite(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<ISaleTypeRepository, SaleTypeRepository>();
            builder.Services.AddSingleton<ISaleRepository, SaleRepository>();
            builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
            builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            builder.Services.AddSingleton<IExpenseRepository, ExpenseRepository>();

            builder.Services.AddSingleton((_) =>
            {
                var database = new SQLiteAsyncConnection(SqLiteConstants.DatabasePath, SqLiteConstants.Flags);

                database.CreateTableAsync<SaleType>().Wait();
                database.CreateTableAsync<Sale>().Wait();
                database.CreateTableAsync<Payment>().Wait();
                database.CreateTableAsync<Customer>().Wait();
                database.CreateTableAsync<Expense>().Wait();

                return database;
            });

            return builder;
        }

        private static MauiAppBuilder SetupNativeCore(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IMappingUiService, MappingUiService>();
            
            return builder;
        }

        private static MauiAppBuilder SetupPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<SettingsViewModel>();

            builder.Services.AddTransient<CustomerDetailPage>();
            builder.Services.AddTransient<CustomerDetailViewModel>();

            builder.Services.AddTransient<SaleTypesPage>();
            builder.Services.AddTransient<SaleTypesViewModel>();

            builder.Services.AddTransient<SaleTypeDetailPage>();
            builder.Services.AddTransient<SaleTypeDetailViewModel>();

            builder.Services.AddTransient<SaleDetailPage>();
            builder.Services.AddTransient<SaleDetailViewModel>();
            
            return builder;
        }
    }
}
