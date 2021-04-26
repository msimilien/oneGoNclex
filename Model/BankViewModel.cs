namespace oneGoNclex.Model
{
    public class BankViewModel
    {
        public BankViewModel()
        {

        }

        public BankViewModel(int bankId, string name, string desc,string im, bool? premium)
        {
            BankId = bankId;
            Name = name;
            Description = desc;
            imageBank = im;
            IsPremium = premium??false;
        }

        public int BankId { get; }
        public string Name { get; }
        public string Description { get; }
        public string imageBank { get; }
        public bool IsPremium { get; }

    }
}