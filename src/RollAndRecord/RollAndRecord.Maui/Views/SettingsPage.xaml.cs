using RollAndRecord.Maui.ViewModels;

namespace RollAndRecord.Maui.Views;

public partial class SettingsPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}