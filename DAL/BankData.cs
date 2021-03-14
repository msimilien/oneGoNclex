using oneGoNclex.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                    CommandText = @"SELECT [IdBank],[Description] FROM [dbo].[Bank]",
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listOfBanks.Add(new BankViewModel(reader.GetInt32(0), reader.GetString(1)));
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
    }
}