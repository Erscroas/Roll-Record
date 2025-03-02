using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Maui.Views.SaleTypeViews;

namespace RollAndRecord.Maui.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task ManageSaleTypes()
        {
            await Shell.Current.GoToAsync(nameof(SaleTypesPage));
        }
    }
}
