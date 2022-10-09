using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace paymentContext.Test.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            
        }

        public bool DocumentExist(string document)
        {
                return document == "99999999999";
        }

        public bool EmailExist(string email)
        {
            return email == "vitor@vitor.com";
        }
    }
}
