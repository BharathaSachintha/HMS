using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using HMS.Model;

namespace HMS.Service
{
    public class LecturePaymentService
    {
        private StringBuilder sb = new StringBuilder();
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        public List<ReceivedPaymentsDto> GetAllData()
        {
            List<ReceivedPaymentsDto> oEmlist = new List<ReceivedPaymentsDto>();
            try
            {

                int sysYear = Convert.ToInt32(DateTime.Now.Year);
                int sysMonth = Convert.ToInt32(DateTime.Now.Month);

                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();


                string q = "select ReceivedPayments.SubjectId,ReceivedPayments.LecturerId,[Subject].SubjectName, Lecturer.FirstName, sum(ReceivedPayments.PriceRate) as Payment from ReceivedPayments INNER JOIN [Subject] ON [Subject].SubjectID = ReceivedPayments.SubjectId INNER JOIN  Lecturer On Lecturer.NICNo = ReceivedPayments.LecturerId WHERE [dbo].[ReceivedPayments].[LectureStatus] =1 group by ReceivedPayments.SubjectId,ReceivedPayments.LecturerId, [Subject].SubjectName, Lecturer.FirstName";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ReceivedPaymentsDto oClass = new ReceivedPaymentsDto();                   
                    oClass.topayment = Convert.ToDouble(dr["Payment"].ToString());
                    oClass.LecturerId = dr["LecturerId"].ToString();
                    oClass.SubjectId = Convert.ToInt32(dr["SubjectId"].ToString());
                    oClass.SubjectName = dr["SubjectName"].ToString();
                    oClass.LectureName = dr["FirstName"].ToString();
                    oEmlist.Add(oClass);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return oEmlist;
            throw new NotImplementedException();
        }
        public List<ReceivedPaymentsDto> GetData(string stID)
        {
            List<ReceivedPaymentsDto> oEmlist = new List<ReceivedPaymentsDto>();
            try
            {

                int sysYear = Convert.ToInt32(DateTime.Now.Year);
                int sysMonth = Convert.ToInt32(DateTime.Now.Month);

                //Last Payment Month/Year

                //int paymentYear;
                //int paymentMonth;

                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();


                string q = "select ReceivedPayments.SubjectId,ReceivedPayments.LecturerId,[Subject].SubjectName, Lecturer.FirstName, sum(ReceivedPayments.PriceRate) as Payment from ReceivedPayments INNER JOIN [Subject] ON [Subject].SubjectID = ReceivedPayments.SubjectId INNER JOIN  Lecturer On Lecturer.NICNo = ReceivedPayments.LecturerId group by ReceivedPayments.SubjectId,ReceivedPayments.LecturerId, [Subject].SubjectName, Lecturer.FirstName";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                cmd.Parameters.AddWithValue("@id", stID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ReceivedPaymentsDto oClass = new ReceivedPaymentsDto();
                    //oClass.PriceRate = dr["PriceRate"].ToString();
                    oClass.topayment =Convert.ToDouble(dr["toPay"].ToString());
                    oClass.LecturerId = dr["LecturerId"].ToString();
                    oClass.SubjectId=Convert.ToInt32(dr["SubjectId"].ToString());
                    oEmlist.Add(oClass);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            return oEmlist;
            throw new NotImplementedException();
        }
        public void Insertdata(LecturePaymentDto oPaydata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO LecturePayment(LectureID,SubjectId,TotalAmount,TransactionDate,Cost) VALUES(@LectureID,@SubjectId,@TotalAmount,@TransactionDate,@Cost)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@LectureID", oPaydata.LectureID);
                cmd.Parameters.AddWithValue("@SubjectId", oPaydata.SubjectID);
                cmd.Parameters.AddWithValue("@TotalAmount", oPaydata.Price);
                cmd.Parameters.AddWithValue("@Cost", oPaydata.Cost);
                cmd.Parameters.AddWithValue("@TransactionDate", oPaydata.TransactionDate);

                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Updatestatus(ReceivedPaymentsDto oStd)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE ReceivedPayments SET LectureStatus='" + oStd.LectureStatus + "' WHERE SubjectId='" + oStd.SubjectId + "' AND LecturerId='" + oStd.LecturerId + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@SubjectId", oStd.SubjectId);
                cmd.Parameters.AddWithValue("@LecturerId", oStd.LecturerId);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int Getrate(string lectureId)
        {
            int result = 0;
            try
            {             
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();


                string q = "SELECT LecturerRate FROM Lecturer WHERE NICNo=@LectureID";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                cmd.Parameters.AddWithValue("@LectureID", lectureId);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result = Convert.ToInt32(dr["LecturerRate"]);
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
