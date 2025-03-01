using CommunityToolkit.Mvvm.ComponentModel;

namespace RollAndRecord.Maui.NativeCore.UIModels;

public partial class UiPayment : ObservableObject
{
    [ObservableProperty] private Guid _id;
    [ObservableProperty] private decimal _amount;
    [ObservableProperty] private DateTime _date;
    [ObservableProperty] private Guid _customerId;
}