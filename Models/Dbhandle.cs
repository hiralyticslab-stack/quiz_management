using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuizMgmt.Models
{
    public class Dbhandle
    {
        SqlConnection con;
        SqlCommand cmd;
        public void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con= new SqlConnection(constr);
        }
        public int u_login(string name, string pass)
        {
            Connection();
            cmd = new SqlCommand("SELECT user_id FROM tblUser WHERE user_name=@name AND user_password=@pass",con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue ("@pass", pass);
            con.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                i = (int)dr["user_id"];
            }
            return i;
        }

        public List<Result> GetResults(int uid)
        {
            Connection();
            string query = @"SELECT r.result_id, r.attempt_date, q.quiz_title, r.score, r.remarks FROM tblResult r INNER JOIN tblQuiz q ON r.quiz_id=q.quiz_id WHERE r.user_id=@uid";
            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@uid",uid);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();            
            List<Result> resultsList = new List<Result>();
            while (dr.Read())
            {
                Result result = new Result
                {
                    result_id = (int)dr["result_id"],
                    attempt_date = (DateTime)dr["attempt_date"],

                    quiz_title = (string)dr["quiz_title"],
                    score = (int)dr["score"],
                    remarks = (string)dr["remarks"],
                };
                resultsList.Add(result);
            }

            con.Close();
            return resultsList;
        }
    }
}