using oneGoNclex.Infraestructure.Repositories;
using oneGoNclex.Model;

namespace oneGoNclex.Services
{
    public static class PaymentService
    {
        public static void InsertPayment(PaymentViewModel model)
        {
            PaymentRepository.InsertPayment(model);   
        }
    }
}