using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            IsActived = true;

            _payments = new List<Payment>();

        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool IsActived { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract<Notification>()
                             .Requires()
                             .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "Paid date cannot be greater than today's date"));

            if(IsValid)
                _payments.Add(payment);
        }

        public void Activate()
        {
            IsActived = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            IsActived = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}
