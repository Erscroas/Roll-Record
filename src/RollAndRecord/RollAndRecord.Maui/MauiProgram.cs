using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RollAndRecord.Core;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using RollAndRecord.Core.Services.Repositories;
using RollAndRecord.Maui.ViewModels;
using RollAndRecord.Maui.Views;
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
            #region SQLite

            builder.Services.AddSingleton<ISaleTypeRepository, SaleTypeRepository>();
            builder.Services.AddSingleton<ISaleRepository, SaleRepository>();
            builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
            builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            builder.Services.AddSingleton<IExpenseRepository, ExpenseRepository>();

            builder.Services.AddSingleton((serviceProvider) =>
            {
                var database = new SQLiteAsyncConnection(SQLiteConsts.DatabasePath, SQLiteConsts.Flags);

                database.CreateTableAsync<SaleType>().Wait();
                database.CreateTableAsync<Sale>().Wait();
                database.CreateTableAsync<Payment>().Wait();
                database.CreateTableAsync<Customer>().Wait();
                database.CreateTableAsync<Expense>().Wait();

                return database;
            });

            #endregion

            return builder;
        }

        private static MauiAppBuilder SetupPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<SettingsViewModel>();

            return builder;
        }
    }
}
