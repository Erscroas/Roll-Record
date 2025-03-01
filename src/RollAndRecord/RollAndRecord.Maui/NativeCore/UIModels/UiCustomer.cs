using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RollAndRecord.Maui.NativeCore.UIModels;

public partial class UiCustomer : ObservableObject
{
    [ObservableProperty] private Guid _id;
    [ObservableProperty] private string _firstName = string.Empty;
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private ObservableCollection<UiSale> _purchases = [];
    [ObservableProperty] private ObservableCollection<UiPayment> _payments = [];
    [ObservableProperty] private decimal _balance;
}