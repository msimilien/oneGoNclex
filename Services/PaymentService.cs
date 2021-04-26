using oneGoNclex.Infraestructure;
using oneGoNclex.Infraestructure.Repositories;
using oneGoNclex.Model;
using System.Collections.Generic;

namespace oneGoNclex.Services
{
    public static class PaymentService
    {
        public static void UpsertPayment(PaymentViewModel model)
        {
            PaymentRepository.UpsertPayment(model);   
        }

        public static int GetDaysBySubscriptionName(string subscriptionName)
        {
            var days = 0;
            switch(subscriptionName)
            {
                case "1 Month":
                    days = 30;
                    break;
                case "3 Months":
                    days = 90;
                    break;
                case "6 Months":
                    days = 180;
                    break;
                case "1 Year":
                    days = 365;
                    break;
            };
            return days;
        }

        public static PaypalPayment CheckSubscriptionAvailableByRegistrationID(string registrationID)
        {
            return PaymentRepository.CheckSubscriptionAvailableByRegistrationID(registrationID);
        }

        public static List<PaymentDetailViewModel> GetAllPaymentsByRegistrationId(string registrationID)
        {
            return PaymentRepository.GetAllPaymentsByRegistrationId(registrationID);
        }
    }
}