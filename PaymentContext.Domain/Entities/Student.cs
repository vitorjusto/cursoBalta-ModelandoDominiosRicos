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
        public Student(string firstName, string lastName, Document document, Email email)
        {
            Name = new Name(firstName, lastName);
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

            if (hasSubcriptionsActive)
                AddNotification("Student.Subscription", "Você já tem uma assinatira ativa");
        }
       
    }
}
