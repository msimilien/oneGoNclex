using System;

namespace oneGoNclex.Model
{
    public class PaymentViewModel
    {
        public string RegistrationId { get; set; }
        public string Email { get; set; }
        public string TicketId { get; set; }
        public string CreationDate { get; set; }
        public string Amount { get; set; }
        public bool IsBankPremium { get; set; }
        public int Days { get; set; }
        public DateTime EndDate { get; set; }

        public PaymentViewModel(
            string registrationId,
            string email,
            string ticketId,
            string creationDate,
            string amount,
            bool isBankPremium,
            int days,
            DateTime endDate)
        {
            RegistrationId = registrationId;
            Email = email;
            TicketId = ticketId;
            CreationDate = creationDate;
            Amount = amount;
            IsBankPremium = isBankPremium;
            Days = days;
            EndDate = endDate;
        }
    }

    public class PaymentDetailViewModel
    {
        public int ID { get; set; }
        public string PaymentDate { get; set; }
        public string IdStudent { get; set; }
        public string Amount { get; set; }
        public string Concept { get; set; }
        public string TransactionID { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateFormat { get; set; }
    }
}