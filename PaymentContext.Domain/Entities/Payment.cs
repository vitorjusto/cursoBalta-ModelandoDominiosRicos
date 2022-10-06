using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Enteties;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpiredDate = expiredDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Document = document;
            Payer = payer;
            Email = email;

            AddNotifications(new Contract<Notification>()
                             .Requires()
                             .IsLowerOrEqualsThan(0, Total, "Payment.Total", "Payment cannot be negative or zero")
                             .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.Total", "Payment value is greater than Total paid"));
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpiredDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
        public Email Email { get; private set; }
    }

}
