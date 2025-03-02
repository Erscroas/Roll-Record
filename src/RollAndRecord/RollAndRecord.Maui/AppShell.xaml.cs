using RollAndRecord.Maui.Views;
using RollAndRecord.Maui.Views.CustomerViews;
using RollAndRecord.Maui.Views.SalePages;
using RollAndRecord.Maui.Views.SaleTypeViews;

namespace RollAndRecord.Maui
{
    public partial class AppShell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(CustomerDetailPage), typeof(CustomerDetailPage));
            
            Routing.RegisterRoute(nameof(SaleTypesPage), typeof(SaleTypesPage));
            Routing.RegisterRoute(nameof(SaleTypeDetailPage), typeof(SaleTypeDetailPage));
            
            Routing.RegisterRoute(nameof(SaleDetailPage), typeof(SaleDetailPage));
            CurrentItem = this.Items.FirstOrDefault(x => x.Route == "MainContent")!.Items.FirstOrDefault(x => x.Route == "Home");
        }
    }
}
