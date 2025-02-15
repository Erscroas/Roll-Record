using RollAndRecord.Maui.ViewModels;

namespace RollAndRecord.Maui.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}