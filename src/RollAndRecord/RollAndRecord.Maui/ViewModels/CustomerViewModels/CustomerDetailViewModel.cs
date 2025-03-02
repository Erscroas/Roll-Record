using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Maui.NativeCore.Interfaces;
using RollAndRecord.Maui.NativeCore.UIModels;
using RollAndRecord.Maui.Views.SalePages;

namespace RollAndRecord.Maui.ViewModels.CustomerViewModels;

[QueryProperty(nameof(CustomerId), nameof(CustomerId))]
public partial class CustomerDetailViewModel(ICustomerRepository customerRepo, IMappingUiService mappingUiService) : ObservableObject
{
    [ObservableProperty] private UiCustomer _customer = new();
    [ObservableProperty] private Guid _customerId;
    [ObservableProperty] private bool _buttonsAvailable;

    [RelayCommand]
    private async Task Appearing()
    {
        if (CustomerId == Guid.Empty) return;

        ButtonsAvailable = true;
        var customer = await customerRepo.Get(CustomerId);
        Customer = mappingUiService.MapCustomer(customer);
    }

    [RelayCommand]
    private async Task Update()
    {
        var customer = mappingUiService.MapCustomer(Customer);
        await customerRepo.Save(customer);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Delete()
    {
        var result = await Shell.Current.DisplayAlert("Delete", "Are you sure you want to delete this customer?", "Yes", "No");
        if(!result) return;

        var customer = mappingUiService.MapCustomer(Customer);
        await customerRepo.Delete(customer);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AddSale()
    {
        await Shell.Current.GoToAsync(nameof(SaleDetailPage), new Dictionary<string, object>
        {
            ["SaleId"] = Guid.Empty
        });
    }

    [RelayCommand]
    private async Task AddPayment()
    {
        var payment = new UiPayment()
        {
            Id = Guid.NewGuid(),
            CustomerId = Customer.Id, 
            Amount = 100, 
            Date = DateTime.Now,
        };

        Customer.Payments.Add(payment);
    }
}