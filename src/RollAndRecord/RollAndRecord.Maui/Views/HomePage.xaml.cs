using RollAndRecord.Maui.ViewModels;

namespace RollAndRecord.Maui.Views;

public partial class HomePage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}