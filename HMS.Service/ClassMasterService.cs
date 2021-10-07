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
    public class ClassMasterService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();
        public List<ClassMasterDto> GetData()
        {
            List<ClassMasterDto> oEmlist = new List<ClassMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT ClassCode,Description,Category,Type,DateOfConduct,StartTime,EndTime FROM [Class]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClassMasterDto oClass = new ClassMasterDto();
                    
                    oClass.ClassCode = dr["ClassCode"].ToString();
                    oClass.Description = dr["Description"].ToString();
                    oClass.Category = dr["Category"].ToString();
                    oClass.Type = dr["Type"].ToString();
                    oClass.DateOfConduct = dr["DateOfConduct"].ToString();
                    oClass.StartTime = dr["StartTime"].ToString();
                    oClass.EndTime = dr["EndTime"].ToString();
                    oEmlist.Add(oClass);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }
        public ClassMasterDto GetViewRecords(string ClasssCode)
        {
            ClassMasterDto result = new ClassMasterDto();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT LecturerID,ClassCode,Description,Category,Type,DateOfConduct,StartTime,EndTime,StartDate,AdmissionFee,MonthlyFee,SubjectID FROM [Class] where ClassCode='" + ClasssCode+"'");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                cmd.Parameters.AddWithValue("@ClassCode", ClasssCode);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result.ClassCode = dr["ClassCode"].ToString();
                    result.LecturerID = dr["LecturerID"].ToString();
                    result.Description = dr["Description"].ToString();
                    result.Category = dr["Category"].ToString();
                    result.Type = dr["Type"].ToString();
                    result.DateOfConduct = dr["DateOfConduct"].ToString();
                    result.StartTime = dr["StartTime"].ToString();
                    result.EndTime = dr["EndTime"].ToString();
                    result.StartDate =Convert.ToDateTime (dr["StartDate"].ToString());
                    result.AdmissionFee=Convert.ToDecimal( dr["AdmissionFee"].ToString());
                    result.MonthlyFee = Convert.ToDecimal(dr["MonthlyFee"].ToString());
                    result.SubjectID = dr["SubjectID"].ToString();

                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public void Insertdata(ClassMasterDto oClsdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO Class (LecturerID,SubjectID,ClassCode,Description,Category,Type,StartDate,AdmissionFee,MonthlyFee,DateOfConduct,StartTime,EndTime,CreateDate) VALUES (@LecturerID,@SubjectID,@ClassCode,@Description,@Category,@Type,@StartDate,@AdmissionFee,@MonthlyFee,@DateOfConduct,@StartTime,@EndTime,@CreateDate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@LecturerID", oClsdata.LecturerID);
                cmd.Parameters.AddWithValue("@SubjectID", oClsdata.SubjectID);
                cmd.Parameters.AddWithValue("@ClassCode", oClsdata.ClassCode);
                cmd.Parameters.AddWithValue("@Description", oClsdata.Description);
                cmd.Parameters.AddWithValue("@Category", oClsdata.Category);
                cmd.Parameters.AddWithValue("@Type", oClsdata.Type);
                cmd.Parameters.AddWithValue("@StartDate", oClsdata.StartDate);
                cmd.Parameters.AddWithValue("@AdmissionFee", oClsdata.AdmissionFee);
                cmd.Parameters.AddWithValue("@MonthlyFee", oClsdata.MonthlyFee);
                cmd.Parameters.AddWithValue("@DateOfConduct", oClsdata.DateOfConduct);
                cmd.Parameters.AddWithValue("@StartTime", oClsdata.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", oClsdata.EndTime);
                cmd.Parameters.AddWithValue("@CreateDate", oClsdata.CreateDate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveStd(ClassMasterDto oCls)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE dbo.Class SET LecturerID='"+ oCls.LecturerID + "',SubjectID='" + oCls.SubjectID + "',Description='" + oCls.Description + "',Category='" + oCls.Category + "',Type='" + oCls.Type + "',StartDate='" + oCls.StartDate + "',AdmissionFee='" + oCls.AdmissionFee + "',MonthlyFee='" + oCls.MonthlyFee + "',DateOfConduct='" + oCls.DateOfConduct + "',StartTime='" + oCls.StartTime + "',EndTime='" + oCls.EndTime + "' WHERE ClassCode='" + oCls.ClassCode + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@LecturerID", oCls.LecturerID);
                cmd.Parameters.AddWithValue("@SubjectID", oCls.SubjectID);
                cmd.Parameters.AddWithValue("@ClassCode", oCls.ClassCode);
                cmd.Parameters.AddWithValue("@Description", oCls.Description);
                cmd.Parameters.AddWithValue("@Category", oCls.Category);
                cmd.Parameters.AddWithValue("@Type", oCls.Type);
                cmd.Parameters.AddWithValue("@StartDate", oCls.StartDate);
                cmd.Parameters.AddWithValue("@AdmissionFee", oCls.AdmissionFee);
                cmd.Parameters.AddWithValue("@MonthlyFee", oCls.MonthlyFee);
                cmd.Parameters.AddWithValue("@DateOfConduct", oCls.DateOfConduct);
                cmd.Parameters.AddWithValue("@StartTime", oCls.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", oCls.EndTime);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oCls.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteStd(String Clas)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM Class WHERE ClassCode='" + Clas + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@ClassCode", Clas);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClassMasterDto> selectLecture()
        {
            List<ClassMasterDto> result = new List<ClassMasterDto>();
            result.Add(new ClassMasterDto {LecturerID = "0", LectureName = "-select-" });
            result.AddRange(this.selectLectures());

            return result;
        }
        public List<ClassMasterDto> selectSubject()
        {
            List<ClassMasterDto> result = new List<ClassMasterDto>();
            result.Add(new ClassMasterDto { SubjectID = "0", SubjectName = "-select-" });
            result.AddRange(this.selectSubjects());

            return result;
        }
        public List<ClassMasterDto> selectSubjects()
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
        public List<ClassMasterDto> selectLectures()
        {
            List<ClassMasterDto> result = new List<ClassMasterDto>();

            SqlConnection Conn = new SqlConnection(_Const);
            sb.Clear();
            sb.Append("select LecturerID,FirstName from Lecturer");
            string quary = sb.ToString();
            SqlCommand cmd = new SqlCommand(quary, Conn);
            Conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClassMasterDto oLec = new ClassMasterDto();
                oLec.LecturerID = dr["LecturerID"].ToString();
                oLec.LectureName = dr["FirstName"].ToString();
                result.Add(oLec);
            }
            Conn.Close();

            return result;

        }
        public bool CheckAvailability(String ClsCode)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT ClassCode FROM [dbo.Class]");
                    sb.AppendLine(" WHERE ClassCode=@ClassCode");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("RFID", ClsCode);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        LectureMasterDto result = new LectureMasterDto();
                        if (dr["ClassCode"] != null)
                        {
                            results = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return results;
        }
    }
}

