using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentContext.Test.Mocks;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using System;

namespace paymentContext.Test
{
    [TestClass]
    public class SubscriptionHandlerTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExist()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoPaymentCommand();
            
            command.FirstName = "teste";
            command.LastName = "teste";
            command.Document = "99999999999";
            command.Email = "vitor@vitor.com";
            command.BarCode = "teste";
            command.BoletoNumber = "teste";
            command.Number = "teste";
            command.PaidDate = DateTime.Now;
            command.ExpiredDate = DateTime.Now.AddDays(5);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Street = "teste";
            command.AddressNumber = "teste";
            command.Neighborhood = "teste";
            command.City = "teste";
            command.State = "teste";
            command.ZipCode = "teste";
            command.Payer = "teste";
            command.PayerDocument = "teste";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste";

            handler.Handle(command);

            Assert.IsFalse(handler.IsValid);
        }
    }
}
