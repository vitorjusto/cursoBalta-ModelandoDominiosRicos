using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace paymentContext.Test.commands
{
    [TestClass]
    public class CreateBoletoPaymentCommandTest
    {
        [TestMethod]
        public void Should_return_error_when_first_name_is_empty()
        {
            var command = new CreateBoletoPaymentCommand();
            command.FirstName = "";

            command.validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void Should_return_error_when_last_name_is_empty()
        {
            var command = new CreateBoletoPaymentCommand();
            command.LastName = "";

            command.validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void Should_return_success_when_first_name_and_last_name_is_not_empty()
        {
            var command = new CreateBoletoPaymentCommand();
            command.FirstName = "Vitor";
            command.LastName = "Justo";

            command.validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}
