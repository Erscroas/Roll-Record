using RollAndRecord.Maui.ViewModels.CustomerViewModels;

namespace RollAndRecord.Maui.Views.CustomerViews;

public partial class CustomerDetailPage
{
    public CustomerDetailPage(CustomerDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}