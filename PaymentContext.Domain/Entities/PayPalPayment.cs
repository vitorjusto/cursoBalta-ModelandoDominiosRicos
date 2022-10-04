using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email, string transactionCode):base(paidDate, expiredDate, total, totalPaid, address, document, payer, email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}
