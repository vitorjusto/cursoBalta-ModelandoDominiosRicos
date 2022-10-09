using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace paymentContext.Test
{
    [TestClass]
    public class StudentQueryTest
    {
        private IList<Student> _students;

        public StudentQueryTest()
        {
                _students = new List<Student>();
            for(int i = 0; i < 10; i++)
            {
                _students.Add(new Student(new Name("teste", i.ToString()), new Document("1234567890" + i.ToString(), EDocumentType.CPF), new Email(i.ToString() + "@vitor.com")));
            }
        }
        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExist()
        {
            var exp = StudentQueries.GetStudentInfo("1111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.IsNull(studn);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678901");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.IsNotNull(studn);
        }
    }
}
