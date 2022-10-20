using CefSharp.WinForms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.ValuesObjects
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void Should_return_error_when_CNPJ_is_invalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        public void Should_return_succes_when_CNPJ_is_valid()
        {

            var doc = new Document("12345678901234", EDocumentType.CNPJ);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        public void Should_return_error_when_CPF_is_invalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        public void Should_return_succes_when_CPF_is_valid()
        {
            var doc = new Document("12345678901", EDocumentType.CPF);
            Assert.IsTrue(doc.IsValid);
        }

        [DataTestMethod]
        [DataRow(true, true)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(false, false)]
        public void cpf(bool c1,bool c2)
        {
            Assert.IsFalse((c1 && c2) && !(c2));
        }

    }
}
