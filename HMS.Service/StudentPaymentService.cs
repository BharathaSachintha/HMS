using HMS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service
{
    public class StudentPaymentService
    {
        private StringBuilder sb = new StringBuilder();
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        public List<ClassMasterDto> selectClass()
        {
            List<ClassMasterDto> result = new List<ClassMasterDto>();
            result.Add(new ClassMasterDto { ClassCode = "0", Category = "-select-" });
            result.AddRange(this.selectSubjects());

            return result;
        }
        public List<ClassMasterDto> selectSubjects()
        {
            List<ClassMasterDto> result = new List<ClassMasterDto>();

            SqlConnection Conn = new SqlConnection(_Const);
            sb.Clear();
            sb.Append("select ClassID,Category from Class");
            string quary = sb.ToString();
            SqlCommand cmd = new SqlCommand(quary, Conn);
            Conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClassMasterDto oSub = new ClassMasterDto();
                oSub.classID = Convert.ToInt64(dr["ClassID"].ToString());
                oSub.Category = dr["Category"].ToString();
                result.Add(oSub);
            }
            Conn.Close();

            return result;

        }
        public List<ClassMasterDto> selectSub()
        {
            List<ClassMasterDto> result = new List<ClassMasterDto>();
            result.Add(new ClassMasterDto { SubjectID = "0", SubjectName = "-select-" });
            result.AddRange(this.selectSubb());

            return result;
        }
        public List<ClassMasterDto> selectSubb()
        {
            List<ClassMasterDto> result = new List<ClassMasterDto>();

            SqlConnection Conn = new SqlConnection(_Const);
            sb.Clear();
            sb.Append("select SubjectID,SubjectName from Subject");
            string quary = sb.ToString();
            SqlCommand cmd = new SqlCommand(quary, Conn);
            Conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClassMasterDto oSub = new ClassMasterDto();
                oSub.SubjectID = dr["SubjectID"].ToString();
                oSub.SubjectName = dr["SubjectName"].ToString();
                result.Add(oSub);
            }
            Conn.Close();

            return result;

        }
        public List<SPaymentDto> GetAllData()
        {
            List<SPaymentDto> oEmlist = new List<SPaymentDto>();
            try
            {

                //int sysYear = Convert.ToInt32(DateTime.Now.Year);
                //int sysMonth = Convert.ToInt32(DateTime.Now.Month);


                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();


                string q = "select Cources.RFID, Student.FirstName, Cources.SubjectID, [Subject].SubjectName, Cources.LectureID, Cources.PriceRate,Cources.PaymentStatus, Payment.LastTransactionDate from Student Inner join Cources ON Student.RFID = Cources.RFID Inner join [Subject] ON [Subject].SubjectID = Cources.SubjectID INNER JOIN Payment ON [Payment].StudentID = Cources.RFID and Payment.SubjectID = Cources.SubjectID and Payment.LecturerID = Cources.LectureID where Cources.PaymentStatus = 1 AND Payment.LastTransactionDate < DATEADD(day, -30, getdate())";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SPaymentDto oClass = new SPaymentDto();
                    oClass.StudentID = dr["RFID"].ToString();
                    oClass.StudentName = dr["FirstName"].ToString();
                    oClass.SubjectName = dr["SubjectName"].ToString();
                    oClass.SubjectID = Convert.ToInt32(dr["SubjectID"].ToString());
                    oClass.LecturerID = dr["LectureID"].ToString();
                    oClass.PriceRate = Convert.ToDouble(dr["PriceRate"]);
                    oClass.LastTransactionDate = Convert.ToDateTime(dr["LastTransactionDate"]);
                    oClass.PaymentStatus = Convert.ToInt32(dr["PaymentStatus"]);
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
        public  List<SPaymentDto> GetData(string stID)
        {
            List<SPaymentDto> oEmlist = new List<SPaymentDto>();
            try
            {

                int sysYear = Convert.ToInt32(DateTime.Now.Year);
                int sysMonth = Convert.ToInt32(DateTime.Now.Month);

                //Last Payment Month/Year

                //int paymentYear;
                //int paymentMonth;

                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();

                string q = "select Cources.RFID, Student.FirstName, Cources.SubjectID, [Subject].SubjectName, Cources.LectureID, Cources.PriceRate,Cources.PaymentStatus, Payment.LastTransactionDate from Student Inner join Cources ON Student.RFID = Cources.RFID Inner join [Subject] ON [Subject].SubjectID = Cources.SubjectID INNER JOIN Payment ON [Payment].StudentID = Cources.RFID and Payment.SubjectID = Cources.SubjectID and Payment.LecturerID = Cources.LectureID where Cources.PaymentStatus = 1 AND Payment.LastTransactionDate < DATEADD(day, -30, getdate()) AND Cources.RFID = @id";
                //string q = "select Cources.RFID, Student.FirstName, Cources.SubjectID, [Subject].SubjectName, " +
                //      "Cources.LectureID, Cources.PriceRate,Cources.PaymentStatus from Student Inner join Cources " +
                //      "ON Student.RFID = Cources.RFID Inner join [Subject] ON [Subject].SubjectID = Cources.SubjectID where Cources.PaymentStatus = 1 AND Payment.LastTransactionDate < DATEADD(day, -30, getdate() " +
                //      "AND Cources.RFID = @id";

                sb.Append(q);

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                cmd.Parameters.AddWithValue("@id", stID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SPaymentDto oClass = new SPaymentDto();
                    oClass.StudentID = dr["RFID"].ToString();
                    oClass.StudentName = dr["FirstName"].ToString();
                    oClass.SubjectName = dr["SubjectName"].ToString();
                    oClass.SubjectID = Convert.ToInt32(dr["SubjectID"].ToString());
                    oClass.LecturerID = dr["LectureID"].ToString();
                    oClass.PriceRate = Convert.ToDouble(dr["PriceRate"]);
                    oClass.PaymentStatus = Convert.ToInt32(dr["PaymentStatus"]);
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
        public void Insertdata(SPaymentDto oPaydata)
        {
            try
            {
                //ReceivedPaymentsDto oPaydata=new ReceivedPaymentsDto();
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO ReceivedPayments(StudentId,SubjectId,LecturerId,PriceRate,PaymentDate,LastTransactionDate,LectureStatus) VALUES(@StudentId,@SubjectId,@LecturerId,@PriceRate,GETDATE(),@LastTransactionDate,@LectureStatus)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@LastTransactionDate", oPaydata.LastTransactionDate);
                cmd.Parameters.AddWithValue("@StudentId", oPaydata.StudentID);
                cmd.Parameters.AddWithValue("@SubjectId", oPaydata.SubjectID);
                cmd.Parameters.AddWithValue("@LecturerId", oPaydata.LecturerID);
                cmd.Parameters.AddWithValue("@PriceRate", oPaydata.PriceRate);
                cmd.Parameters.AddWithValue("@LectureStatus", oPaydata.LectureStatus);

                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LastPayment(SPaymentDto oStd)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE Payment SET LastTransactionDate='" + oStd.LastTransactionDate + "' WHERE StudentID='" + oStd.StudentID + "' AND SubjectID='" + oStd.SubjectID + "' AND LecturerID='" + oStd.LecturerID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@StudentID", oStd.StudentID);
                cmd.Parameters.AddWithValue("@SubjectID", oStd.SubjectID);
                cmd.Parameters.AddWithValue("@LecturerID", oStd.LecturerID);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public List<LectureMasterDto> selectLecture()
        {
            List<LectureMasterDto> result = new List<LectureMasterDto>();
            result.Add(new LectureMasterDto { LecturerID = 0, FirstName = "-select-" });
            result.AddRange(this.selectLectu());

            return result;
        }
        public List<LectureMasterDto> selectLectu()
        {
            List<LectureMasterDto> result = new List<LectureMasterDto>();

            SqlConnection Conn = new SqlConnection(_Const);
            sb.Clear();
            sb.Append("select LecturerID,FirstName from Lecturer");
            string quary = sb.ToString();
            SqlCommand cmd = new SqlCommand(quary, Conn);
            Conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LectureMasterDto oSub = new LectureMasterDto();
                oSub.LecturerID = Convert.ToInt32(dr["LecturerID"].ToString());
                oSub.FirstName = dr["FirstName"].ToString();
                result.Add(oSub);
            }
            Conn.Close();

            return result;

        }
        public void Changepyament(SPaymentDto oStd)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE dbo.Payment SET Payment='" + oStd.Payment + "' WHERE StudentID='" + oStd.StudentID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@StudentID", oStd.StudentID);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
       
    }
}
