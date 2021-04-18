using oneGoNclex.DAL;
using oneGoNclex.Model;
using System.Collections.Generic;

namespace oneGoNclex.Services
{
    public class BankService
    {
        public static List<BankViewModel> GetBanks() => BankData.GetBanks();
        public static BankViewModel GetById(int bankId) => BankData.GetById(bankId);
    }
}