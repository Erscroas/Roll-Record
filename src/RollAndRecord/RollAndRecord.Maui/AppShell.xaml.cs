using RollAndRecord.Maui.Views;
using RollAndRecord.Maui.Views.CustomerViews;

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
            CurrentItem = this.Items.FirstOrDefault(x => x.Route == "MainContent")!.Items.FirstOrDefault(x => x.Route == "Home");
        }
    }
}
