using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using System.Collections.ObjectModel;

namespace RollAndRecord.Maui.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        #region Properties

        [ObservableProperty]
        private ObservableCollection<Customer>? _customers;

        #endregion

        private readonly ICustomerRepository _customerRepo;

        public HomeViewModel(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [RelayCommand]
        private async Task Appearing()
        {
            var customers = await _customerRepo.All();

            if(customers == null || !customers.Any())
            {
                // add some default customers

                customers = new List<Customer>
                {
                    new Customer { Id = Guid.NewGuid(), Firstname = "John", Name = "Doe"},
                    new Customer { Id = Guid.NewGuid(), Firstname = "Jane", Name = "Doe"},
                    new Customer { Id = Guid.NewGuid(), Firstname = "Alice", Name = "Smith"},
                    new Customer { Id = Guid.NewGuid(), Firstname = "Bob", Name = "Smith"},
                    new Customer { Id = Guid.NewGuid(), Firstname = "Charlie", Name = "Brown"},
                };
            }

            Customers = new ObservableCollection<Customer>(customers);
        }
    }
}
