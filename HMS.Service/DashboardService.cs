using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service
{
    public class DashboardService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();

        public int GetstudentCount()
        {
            int result = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();


                string q = "Select Count(RFID) as StudentCount FROM Student";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result = Convert.ToInt32(dr["StudentCount"]);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int GetMonthlyIncome()
        {
            int result = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();


                string q = "Select SUM(TotalAmount) as MonthlyIncome FROM LecturePayment";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result = Convert.ToInt32(dr["MonthlyIncome"]);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int GetClassCount()
        {
            int result = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();


                string q = "Select Count(ClassCode) as ClassCount FROM Class";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result = Convert.ToInt32(dr["ClassCount"]);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }

}
