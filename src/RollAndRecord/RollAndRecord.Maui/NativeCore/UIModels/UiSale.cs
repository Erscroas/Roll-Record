using CommunityToolkit.Mvvm.ComponentModel;

namespace RollAndRecord.Maui.NativeCore.UIModels;

public partial class UiSale : ObservableObject
{
    [ObservableProperty] private Guid _id;
    [ObservableProperty] private DateTime _date;
    [ObservableProperty] private decimal _amount;
    [ObservableProperty] private Guid _customerId;
    [ObservableProperty] private Guid _saleTypeId;
}