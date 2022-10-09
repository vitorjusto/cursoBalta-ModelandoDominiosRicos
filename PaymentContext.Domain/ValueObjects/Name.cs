using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
                AddNotification("FirstName", "First name can't be empty.");

            if (string.IsNullOrEmpty(LastName))
                AddNotification("LastName", "Last name can't be empty.");

            AddNotifications(new Contract<Notification>()
                             .Requires()
                             .IsNotNullOrEmpty(FirstName, "Name.FirstName", "First name can't be empty.")
                             .IsNotNullOrEmpty(LastName, "Name.LastName", "Last name can't be empty."));
                             
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
