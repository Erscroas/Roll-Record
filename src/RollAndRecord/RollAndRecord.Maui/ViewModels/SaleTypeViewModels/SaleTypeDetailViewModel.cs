using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;

namespace RollAndRecord.Maui.ViewModels.SaleTypeViewModels;

[QueryProperty(nameof(SaleTypeId), nameof(SaleTypeId))]
public partial class SaleTypeDetailViewModel(ISaleTypeRepository saleTypeRepository) : ObservableObject
{
    [ObservableProperty] private Guid _saleTypeId;
    [ObservableProperty] private SaleType _saleType = new();
    
    [RelayCommand]
    private async Task Appearing()
    {
        if(SaleTypeId == Guid.Empty) return;

        var saleType = await saleTypeRepository.Get(SaleTypeId);
        SaleType = saleType;
    }

    [RelayCommand]
    private async Task Save()
    {
        await saleTypeRepository.Save(SaleType);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Delete()
    {
        var result = await Shell.Current.DisplayAlert("Delete", "Are you sure you want to delete this type?", "Yes", "No");
        if(!result) return;

        await saleTypeRepository.Delete(SaleType);
        await Shell.Current.GoToAsync("..");
    }
}