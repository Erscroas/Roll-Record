using RollAndRecord.Maui.Views;

namespace RollAndRecord.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            CurrentItem = this.Items.FirstOrDefault(x => x.Route == "MainContent")!.Items.FirstOrDefault(x => x.Route == "Home");
        }
    }
}
