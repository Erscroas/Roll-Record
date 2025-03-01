using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using System.Collections.ObjectModel;
using RollAndRecord.Maui.Views.CustomerViews;

namespace RollAndRecord.Maui.ViewModels
{
    public partial class HomeViewModel(ICustomerRepository customerRepo) : ObservableObject
    {
        #region Properties

        [ObservableProperty] private ObservableCollection<Customer> _customers = [];
        [ObservableProperty] private Customer? _selectedCustomer;

        #endregion

        [RelayCommand]
        private async Task Appearing()
        {
            var customers = await customerRepo.All();
            Customers = new ObservableCollection<Customer>(customers);
        }

        [RelayCommand]
        private async Task AddCustomer()
        {
            await Shell.Current.GoToAsync($"{nameof(CustomerDetailPage)}", new Dictionary<string, object>
            {
                ["CustomerId"] = Guid.Empty
            });
        }

        [RelayCommand]
        private async Task CustomerSelected()
        {
            if(SelectedCustomer == null) return;
            
            await Shell.Current.GoToAsync($"{nameof(CustomerDetailPage)}", new Dictionary<string, object>
            {
                ["CustomerId"] = SelectedCustomer.Id
            });
        }
    }
}
