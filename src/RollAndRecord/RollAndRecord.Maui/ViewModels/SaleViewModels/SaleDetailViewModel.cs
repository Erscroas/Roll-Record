using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;

namespace RollAndRecord.Maui.ViewModels.SaleViewModels;

[QueryProperty(nameof(SaleId), nameof(SaleId))]
public partial class SaleDetailViewModel(ISaleRepository saleRepository, ISaleTypeRepository saleTypeRepository) : ObservableObject
{
    [ObservableProperty] private Guid _saleId;
    [ObservableProperty] private Sale _sale = new();
    [ObservableProperty] private ObservableCollection<SaleType> _saleTypes = [];
    [ObservableProperty] private SaleType? _selectedSaleType;
    
    [RelayCommand]
    private async Task Appearing()
    {
        var saleTypes = await saleTypeRepository.All();
        if (saleTypes.Count > 0)
            SaleTypes = new ObservableCollection<SaleType>(saleTypes);
        if (SaleId == Guid.Empty) return;
        Sale = await saleRepository.Get(SaleId);
        
    }
}