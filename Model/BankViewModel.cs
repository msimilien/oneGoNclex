namespace oneGoNclex.Model
{
    public class BankViewModel
    {
        public BankViewModel()
        {

        }

        public BankViewModel(int bankId, string name, string desc,string im)
        {
            BankId = bankId;
            Name = name;
            Description = desc;
            imageBank = im;
        }

        public int BankId { get; }
        public string Name { get; }
        public string Description { get; }
        public string imageBank { get; }

    }
}