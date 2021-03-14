using oneGoNclex.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace oneGoNclex.Services
{
    public class ExamService
    {
        public static List<ExamViewModel> GetQuestionsByBankId(int bankID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"SELECT Question
                                          ,id
                                          ,pictureQuestion
                                          ,'' as videoQuestion
                                      FROM Questions
                                    where BankId=" + bankID,
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();
                var list = new List<ExamViewModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new ExamViewModel(reader.GetGuid(1), reader.GetString(0), reader.GetString(2), reader.GetString(3)));
                    }
                }

                reader.Close();

                return list;
            }
            catch (Exception ex)
            {
                return new List<ExamViewModel>();
            }
        }
    }
}