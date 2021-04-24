using oneGoNclex.Model;
using System;
using System.Collections.Generic;
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

                    db.SaveChanges();

                    payment = db.PaypalPayments.Single(x => x.IdStudent == registrationID);
                }

                return payment.EndDate >= DateTime.Now;
            }
        }

        public static List<PaymentDetailViewModel> GetAllPaymentsByRegistrationId(string registrationID)
        {
            var listOfPayments = new List<PaymentDetailViewModel>();
            using (var db = new NCLEXREVIEWEntities())
            {
                var payment = db.PaypalPayments.FirstOrDefault(x => x.IdStudent == registrationID);

                if (payment != null)
                {
                    listOfPayments.Add(new PaymentDetailViewModel
                    {
                        Amount = $"{payment.Amount} $USD",
                        Concept = payment.Concept,
                        EndDate = payment.EndDate.ToString("yyyy-MM-dd"),
                        IdStudent = payment.IdStudent,
                        SubscriptionType = payment.IsBankPremium ? "Premium" : "Normal",
                        PaymentDate = payment.PaymentDate.ToString("yyyy-MM-dd"),
                        TransactionID = payment.TransactionID
                    });
                }

                if (db.PaypalPaymentHistories.FirstOrDefault(x => x.IdStudent == registrationID) != null)
                {
                    var paymentHistory = db.PaypalPaymentHistories
                                       .Where(x => x.IdStudent == registrationID)
                                       .Take(10)
                                       .AsEnumerable()
                                       .Select(x => new PaymentDetailViewModel
                                       {
                                           Amount = $"{x.Amount} $USD",
                                           Concept = x.Concept,
                                           EndDate = x.EndDate.ToString("yyyy-MM-dd"),
                                           IdStudent = x.IdStudent,
                                           SubscriptionType = x.IsBankPremium ? "Premium" : "Normal",
                                           PaymentDate = x.PaymentDate.ToString("yyyy-MM-dd"),
                                           TransactionID = x.TransactionID
                                       });

                    listOfPayments.AddRange(paymentHistory);
                }

                return listOfPayments;
            }
        }
    }
}