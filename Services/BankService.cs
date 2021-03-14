using oneGoNclex.DAL;
using oneGoNclex.Model;
using System.Collections.Generic;

namespace oneGoNclex.Services
{
    public class BankService
    {
        public static List<BankViewModel> GetBanks()
        {
            return BankData.GetBanks();
        }
    }
}