using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Notification>().Requires().IsEmail(Address, "Addres", "E-mail Address is invalid"));
        }

        public string Address { get; private set; }


    }
}
