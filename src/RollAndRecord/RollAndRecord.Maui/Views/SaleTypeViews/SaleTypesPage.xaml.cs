using RollAndRecord.Maui.ViewModels.SaleTypeViewModels;

namespace RollAndRecord.Maui.Views.SaleTypeViews;

public partial class SaleTypesPage
{
    public SaleTypesPage(SaleTypesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}