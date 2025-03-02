using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using RollAndRecord.Maui.Views.SaleTypeViews;

namespace RollAndRecord.Maui.ViewModels.SaleTypeViewModels;

public partial class SaleTypesViewModel(ISaleTypeRepository saleTypeRepository) : ObservableObject
{
    [ObservableProperty] private ObservableCollection<SaleType> _saleTypes = [];
    [ObservableProperty] private SaleType? _selectedSaleType;
    
    [RelayCommand]
    private async Task Appearing()
    {
        var saleTypes = await saleTypeRepository.All();

        if (saleTypes.Count == 0) return;
        
        SaleTypes = new ObservableCollection<SaleType>(saleTypes);
    }

    [RelayCommand]
    private async Task AddSaleType()
    {
        await Shell.Current.GoToAsync($"{nameof(SaleTypeDetailPage)}", new Dictionary<string, object>
        {
            ["SaleTypeId"] = Guid.Empty
        });
    }

    [RelayCommand]
    private async Task SaleTypeSelected()
    {
        if (SelectedSaleType == null) return;
        
        await Shell.Current.GoToAsync($"{nameof(SaleTypeDetailPage)}", new Dictionary<string, object>
        {
            ["SaleTypeId"] = SelectedSaleType.Id
        });
    }
}