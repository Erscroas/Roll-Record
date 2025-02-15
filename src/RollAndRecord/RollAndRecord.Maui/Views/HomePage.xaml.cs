using RollAndRecord.Maui.ViewModels;

namespace RollAndRecord.Maui.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}