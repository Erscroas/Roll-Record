using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollAndRecord.Maui.ViewModels.SaleTypeViewModels;

namespace RollAndRecord.Maui.Views.SaleTypeViews;

public partial class SaleTypeDetailPage
{
    public SaleTypeDetailPage(SaleTypeDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}