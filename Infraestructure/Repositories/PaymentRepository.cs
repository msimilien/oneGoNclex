using oneGoNclex.Model;
using System;

namespace oneGoNclex.Infraestructure.Repositories
{
    public static class PaymentRepository
    {
        public static void InsertPayment(PaymentViewModel model)
        {
            using (var db = new NCLEXREVIEWEntities())
            {
                db.PaypalPayments.Add(new PaypalPayment
                {
                    Amount = decimal.Parse(model.Amount),
                    BankID = model.BankId,
                    Concept = "Payment for exam",
                    IdStudent = model.RegistrationId,
                    PaymentDate = DateTime.Parse(model.CreationDate)
                });

                db.SaveChanges();
            }
        }
    }
}