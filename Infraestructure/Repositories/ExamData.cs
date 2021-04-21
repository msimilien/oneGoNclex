using oneGoNclex.Model;
using System;
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
	                                       ,ISNULL(d.Explanation, '') as Explanation
                                    from Questions a WITH(NOLOCK)
                                    join Responses b WITH(NOLOCK) on a.id = b.IdQ
                                    join [Subject] c WITH(NOLOCK) on a.[Subject] = c.id
                                    left join ExplanationQuestion d WITH(NOLOCK) on a.id = d.IdQuestion
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

        public static bool RegisterExamResult(ExamResultViewModel model)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.myConnection);
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = @"INSERT INTO [dbo].[Student_Result]
                                           ([IdStudent]
                                           ,[idExam]
                                           ,[Point]
                                           ,[qualification])
                                     VALUES
                                           (@RegistrationID
                                           ,@BankId
                                           ,@Points
                                           ,@Qualification)",
                    Connection = conn
                };

                cmd.Parameters.AddWithValue("@RegistrationID", model.StudentID);
                cmd.Parameters.AddWithValue("@BankId", model.BankID);
                cmd.Parameters.AddWithValue("@Points", model.Point);
                cmd.Parameters.AddWithValue("@Qualification", model.Qualification);

                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}