using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;

namespace paymentContext.Test.Entities
{
    [TestClass]
    public class StudentTest
    {

        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _doc;
        private readonly Email _email;
        private readonly Address _address;

        public StudentTest()
        {
            _name = new Name("Tony", "Stark");
            _doc = new Document("12345678901", EDocumentType.CPF);
            _email = new Email("IronMan@mv.com");
            _address = new Address("sttreeed", "1234", "neiborhood", "city", "state", "12345123");
            _student = new Student(_name, _doc, _email);
            _subscription = new Subscription(null);
            
        }

        [TestMethod]
        public void Should_return_error_when_had_active_subscription()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _doc, "shield", _email, "123");

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void Should_return_error_when_has_no_payment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void Should_return_success_when_had_no_active_subscription()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _doc, "shield", _email, "123");

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.IsValid);
        }
    }
}
