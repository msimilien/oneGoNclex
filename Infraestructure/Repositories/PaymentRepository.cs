using oneGoNclex.Model;
using System;
using System.Linq;

namespace oneGoNclex.Infraestructure.Repositories
{
    public static class PaymentRepository
    {
        private const int DAYS_OF_THREE_WEEKS = 21;
        public static void UpsertPayment(PaymentViewModel model)
        {
            using (var db = new NCLEXREVIEWEntities())
            {
                var payment = db.PaypalPayments.FirstOrDefault(x => x.IdStudent == model.RegistrationId);
                if (payment == null)
                {
                    db.PaypalPayments.Add(new PaypalPayment
                    {
                        Amount = decimal.Parse(model.Amount),
                        EndDate = DateTime.Parse(model.CreationDate).AddDays(DAYS_OF_THREE_WEEKS),
                        TransactionID = model.TicketId,
                        IsBankPremium = model.IsBankPremium,
                        Concept = "Payment for exam",
                        IdStudent = model.RegistrationId,
                        PaymentDate = DateTime.Parse(model.CreationDate)
                    });
                }
                else
                {
                    db.PaypalPaymentHistories.Add(new PaypalPaymentHistory
                    {
                        Amount = payment.Amount,
                        EndDate = payment.EndDate,
                        TransactionID = payment.TransactionID,
                        IsBankPremium = payment.IsBankPremium,
                        Concept = payment.Concept,
                        IdStudent = payment.IdStudent,
                        PaymentDate = payment.PaymentDate
                    });

                    payment.Amount = decimal.Parse(model.Amount);
                    payment.EndDate = model.EndDate;
                    payment.TransactionID = model.TicketId;
                    payment.IsBankPremium = model.IsBankPremium;
                    payment.Concept = "Payment for exam";
                    payment.IdStudent = model.RegistrationId;
                    payment.PaymentDate = DateTime.Parse(model.CreationDate);
                }

                db.SaveChanges();
            }
        }
        public static bool CheckSubscriptionAvailableByRegistrationID(string registrationID)
        {
            using (var db = new NCLEXREVIEWEntities())
            {
                var payment = db.PaypalPayments.FirstOrDefault(x => x.IdStudent == registrationID);
                
                if (payment == null)
                {
                    db.PaypalPayments.Add(new PaypalPayment
                    {
                        Amount = 0,
                        EndDate = DateTime.Now.AddDays(DAYS_OF_THREE_WEEKS),
                        TransactionID = string.Empty,
                        IsBankPremium = false,
                        Concept = "Test period",
                        IdStudent = registrationID,
                        PaymentDate = DateTime.Now
                    });

                    payment = db.PaypalPayments.Single(x => x.IdStudent == registrationID);
                }

                return payment.EndDate >= DateTime.Now;
            }
        }
    }
}