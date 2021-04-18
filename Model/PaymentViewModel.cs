namespace oneGoNclex.Model
{
    public class PaymentViewModel
    {
        public string RegistrationId { get; set; }
        public string Email { get; set; }
        public int BankId { get; set; }
        public string TicketId { get; set; }
        public string CreationDate { get; set; }
        public string Amount { get; set; }

        public PaymentViewModel(
            string registrationId,
            string email,
            int bankId,
            string ticketId,
            string creationDate,
            string amount)
        {
            RegistrationId = registrationId;
            Email = email;
            BankId = bankId;
            TicketId = ticketId;
            CreationDate = creationDate;
            Amount = amount;
        }
    }
}