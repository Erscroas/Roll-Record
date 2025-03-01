using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;

namespace RollAndRecord.Maui.ViewModels.CustomerViewModels;

[QueryProperty(nameof(Customer), nameof(Customer))]
public partial class CustomerDetailViewModel(ICustomerRepository customerRepo) : ObservableObject
{
    [ObservableProperty] private Customer _customer = new();

    private bool _isNewCustomer;

    [RelayCommand]
    private async Task Appearing()
    {
        _isNewCustomer = Customer.Id == Guid.Empty;

        if (_isNewCustomer)
        {
            Customer = new Customer {Id = Guid.NewGuid()};
            return;
        }
        
        Customer = await customerRepo.Get(Customer.Id);
    }

    [RelayCommand]
    private async Task Update()
    {
        await customerRepo.Save(Customer);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Delete()
    {
        var result = await Shell.Current.DisplayAlert("Delete", "Are you sure you want to delete this customer?", "Yes", "No");
        if(!result) return;
        
        await customerRepo.Delete(Customer);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AddSale()
    {
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            CustomerId = Customer.Id, 
            Amount = 100, 
            Date = DateTime.Now,
            SaleTypeId = Guid.NewGuid()
        };

        Customer.Purchases.Add(sale);
    }

    [RelayCommand]
    private async Task AddPayment()
    {
        var payment = new Payment()
        {
            Id = Guid.NewGuid(),
            CustomerId = Customer.Id, 
            Amount = 100, 
            Date = DateTime.Now,
        };

        Customer.Payments.Add(payment);
    }
}