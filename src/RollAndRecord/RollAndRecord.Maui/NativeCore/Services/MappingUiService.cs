using System.Collections.ObjectModel;
using RollAndRecord.Core.Models;
using RollAndRecord.Maui.NativeCore.Interfaces;
using RollAndRecord.Maui.NativeCore.UIModels;

namespace RollAndRecord.Maui.NativeCore.Services;

public class MappingUiService : IMappingUiService
{
    public UiCustomer MapCustomer(Customer customer)
    {
        return new UiCustomer
        {
            Id = customer.Id,
            Name = customer.Name,
            FirstName = customer.Firstname,
            Payments = new ObservableCollection<UiPayment>(customer.Payments.Select(MapPayment).ToList()),
            Purchases = new ObservableCollection<UiSale>(customer.Purchases.Select(MapSale).ToList()),
        };
    }

    public Customer MapCustomer(UiCustomer uiCustomer)
    {
        return new Customer
        {
            Id = uiCustomer.Id,
            Name = uiCustomer.Name,
            Firstname = uiCustomer.FirstName,
            Payments = uiCustomer.Payments.Select(MapPayment).ToList(),
            Purchases = uiCustomer.Purchases.Select(MapSale).ToList()
        };
    }

    public UiPayment MapPayment(Payment payment)
    {
        return new UiPayment
        {
            Id = payment.Id,
            CustomerId = payment.CustomerId,
            Amount = payment.Amount,
            Date = payment.Date,
        };
    }
    

    public Payment MapPayment(UiPayment payment)
    {
        return new Payment
        {
            Id = payment.Id,
            CustomerId = payment.CustomerId,
            Amount = payment.Amount,
            Date = payment.Date
        };
    }

    public UiSale MapSale(Sale sale)
    {
        return new UiSale
        {
            Id = sale.Id,
            Date = sale.Date,
            Amount = sale.Amount,
            CustomerId = sale.CustomerId,
            SaleTypeId = sale.SaleTypeId
        };
    }

    public Sale MapSale(UiSale sale)
    {
        return new Sale
        {
            Id = sale.Id,
            Date = sale.Date,
            Amount = sale.Amount,
            CustomerId = sale.CustomerId,
            SaleTypeId = sale.SaleTypeId
        };
    }
}