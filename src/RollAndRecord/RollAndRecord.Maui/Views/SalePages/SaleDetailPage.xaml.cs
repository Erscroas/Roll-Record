using RollAndRecord.Maui.ViewModels.SaleViewModels;

namespace RollAndRecord.Maui.Views.SalePages;

public partial class SaleDetailPage
{
    public SaleDetailPage(SaleDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}