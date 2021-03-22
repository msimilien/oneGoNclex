using oneGoNclex.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace oneGoNclex.DAL
{
    public class ExamData
    {
        public static List<ExamViewModel> GetQuestionsByBankId(int bankID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"select a.id
                                           ,c.[Subject]
                                           ,a.Question
                                           ,a.QuestionType
                                           ,a.pictureQuestion
                                           ,b.Response
                                           ,b.Asset
	                                       ,d.Explanation
                                    from Questions a
                                    join Responses b on a.id = b.IdQ
                                    join [Subject] c on a.[Subject] = c.id
                                    left join ExplanationQuestion d on a.id = d.IdQuestion
                                    where a.BankId = " + bankID,
                    Connection = conn
                };

                conn.Open();
                var reader = cmd.ExecuteReader();
                var list = new List<ExamViewModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new ExamViewModel(reader.GetGuid(0),
                                                   reader.GetString(2),
                                                   reader.GetString(3),
                                                   reader.GetString(4),
                                                   reader.GetString(1),
                                                   reader.GetString(5),
                                                   reader.GetBoolean(6),
                                                   reader.GetString(7)));
                    }
                }

                reader.Close();

                return list;
            }
            catch
            {
                return new List<ExamViewModel>();
            }
        }
    }
}