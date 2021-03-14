namespace oneGoNclex.Model
{
    public class BankViewModel
    {
        public BankViewModel()
        {

        }

        public BankViewModel(int bankId, string name)
        {
            BankId = bankId;
            Name = name;
        }

        public int BankId { get; }
        public string Name { get; }
    }
}