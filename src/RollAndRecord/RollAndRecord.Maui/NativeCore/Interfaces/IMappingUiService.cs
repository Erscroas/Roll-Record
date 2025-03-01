using RollAndRecord.Core.Models;
using RollAndRecord.Maui.NativeCore.UIModels;

namespace RollAndRecord.Maui.NativeCore.Interfaces;

public interface IMappingUiService
{
    UiCustomer MapCustomer(Customer customer);
    Customer MapCustomer(UiCustomer uiCustomer);
    
    UiPayment MapPayment(Payment payment);
    Payment MapPayment(UiPayment payment);
    
    UiSale MapSale(Sale sale);
    Sale MapSale(UiSale sale);
}