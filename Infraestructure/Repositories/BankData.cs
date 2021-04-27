using oneGoNclex.Infraestructure;
using oneGoNclex.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace oneGoNclex.DAL
{
    public class BankData
    {
        public static List<BankViewModel> GetBanks()
        {
            var listOfBanks = new List<BankViewModel>();

            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"SELECT [IdBank],[Description],[BankName],[ImageBank],[IsBankPremium] FROM [dbo].[Bank] WITH(NOLOCK) WHERE Actif=1 ",
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listOfBanks.Add(new BankViewModel(reader.GetInt32(0), reader.GetString(2), reader.GetString(1), reader.GetString(3),reader.GetBoolean(4)));
                    }
                }

                reader.Close();

                return listOfBanks;
            }
            catch
            {
                return listOfBanks;
            }
        }

        public static BankViewModel GetById(int bankId)
        {
            using (var db = new NCLEXREVIEWEntities())
            {
                var bank = db.Banks.Single(x => x.IdBank == bankId);
                return new BankViewModel(bankId, bank.BankName, bank.Description, bank.ImageBank,bank.IsBankPremium);
            }
        }
    }
}