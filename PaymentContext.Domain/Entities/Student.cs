using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Enteties;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(Name, Document, Email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubcriptionsActive = false;
            foreach(var sub in _subscriptions)
            {
                if (sub.IsActived)
                    hasSubcriptionsActive = true;
            }

            AddNotifications(new Contract<Notification>()
                             .Requires()
                             .IsFalse(hasSubcriptionsActive, "Student.Subscription", "You already have an active subscription")
                             .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "This subscription don't have any payment"));

            
        }
       
    }
}
