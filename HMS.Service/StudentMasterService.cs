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
    public class StudentMasterService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();
        public List<StudentMasterDto> GetData()
        {
            List<StudentMasterDto> oEmlist = new List<StudentMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT Initials,LastName,GuardianName,SchoolName,DateOfBirth,RFID,FirstName,Gender,ContactNo,Address,StudCategory FROM [Student]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    StudentMasterDto oStd = new StudentMasterDto();
                    oStd.RFID= dr["RFID"].ToString();
                    oStd.FirstName = dr["FirstName"].ToString();
                    oStd.Gender = dr["Gender"].ToString();
                    oStd.ContactNo = Convert.ToInt32(dr["ContactNo"].ToString());
                    oStd.Address = dr["Address"].ToString();
                    oStd.StudCategory = dr["StudCategory"].ToString();
                    oStd.Initials=dr["Initials"].ToString();
                    oStd.LastName=dr["LastName"].ToString();
                    oStd.GuardianName=dr["GuardianName"].ToString();
                    oStd.SchoolName=dr["SchoolName"].ToString();
                    oStd.DateOfBirth=Convert.ToDateTime (dr["DateOfBirth"].ToString());
                    oEmlist.Add(oStd);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }
        public List<LecturesSubjectsDto> GetfilterList(int subcat)
        {
            List<LecturesSubjectsDto> result = new List<LecturesSubjectsDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT LecturesSubjects.LectureID, LecturesSubjects.SubjectCatID, LecturesSubjects.SubjectID, LecturesSubjects.SubjectName,LecturesSubjects.PriceRate, Lecturer.FirstName, Lecturer.LastName FROM LecturesSubjects INNER JOIN Lecturer ON Lecturer.NICNo = LecturesSubjects.LectureID WHERE LecturesSubjects.SubjectCatID='" + subcat + "' ORDER BY LecturesSubjects.LectureID desc");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                cmd.Parameters.AddWithValue("@SubjectCatID", subcat);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LecturesSubjectsDto oget = new LecturesSubjectsDto();
                    oget.LectureID = dr["LectureID"].ToString();
                    oget.LectureName = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                    oget.SubjectCatID = Convert.ToInt32(dr["SubjectCatID"]);
                    oget.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oget.SubjectName = dr["SubjectName"].ToString();
                    oget.PriceRate = Convert.ToDecimal(dr["PriceRate"]);
                    result.Add(oget);
                }
                Conn.Close();
                sb.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<LecturesSubjectsDto> GetfilterAllList()
        {
            List<LecturesSubjectsDto> result = new List<LecturesSubjectsDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT LecturesSubjects.LectureID, LecturesSubjects.SubjectCatID, LecturesSubjects.SubjectID, LecturesSubjects.SubjectName,LecturesSubjects.PriceRate, Lecturer.FirstName, Lecturer.LastName FROM LecturesSubjects INNER JOIN Lecturer ON Lecturer.NICNo = LecturesSubjects.LectureID ORDER BY LecturesSubjects.SubjectCatID desc");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LecturesSubjectsDto oget = new LecturesSubjectsDto();
                    oget.LectureID = dr["LectureID"].ToString();
                    oget.LectureName = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                    oget.SubjectCatID = Convert.ToInt32(dr["SubjectCatID"]);
                    oget.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oget.SubjectName = dr["SubjectName"].ToString();
                    oget.PriceRate = Convert.ToDecimal(dr["PriceRate"]);
                    result.Add(oget);
                }
                Conn.Close();
                sb.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<LecturesSubjectsDto> GetList()
        {
            List<LecturesSubjectsDto> result = new List<LecturesSubjectsDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT LecturesSubjects.LectureID, LecturesSubjects.SubjectCatID, LecturesSubjects.SubjectID, LecturesSubjects.SubjectName,LecturesSubjects.PriceRate FROM LecturesSubjects");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LecturesSubjectsDto oget = new LecturesSubjectsDto();
                    oget.LectureID = dr["LectureID"].ToString();
                    oget.SubjectCatID = Convert.ToInt32(dr["SubjectCatID"]);
                    oget.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oget.SubjectName = dr["SubjectName"].ToString();
                    oget.PriceRate = Convert.ToDecimal(dr["PriceRate"]);
                    result.Add(oget);
                }
                Conn.Close();
                sb.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<LecturesSubjectsDto> GEtCourses(string RFID)
        {
            List<LecturesSubjectsDto> result = new List<LecturesSubjectsDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();
                sb.Append("SELECT Cources.LectureID, Cources.SubjectCatID, Cources.SubjectID, Subject.SubjectName, Cources.PriceRate, Lecturer.FirstName, Lecturer.LastName FROM Cources INNER JOIN Lecturer ON Lecturer.NICNo = Cources.LectureID INNER JOIN Subject ON Subject.SubjectID = Cources.SubjectID WHERE Cources.RFID='" + RFID + "' ORDER BY Cources.SubjectID desc");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                cmd.Parameters.AddWithValue("@LectureID", RFID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LecturesSubjectsDto oget = new LecturesSubjectsDto();
                    oget.LectureID = dr["LectureID"].ToString();
                    oget.LectureName = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                    oget.SubjectCatID = Convert.ToInt32(dr["SubjectCatID"]);
                    oget.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oget.SubjectName = dr["SubjectName"].ToString();
                    oget.PriceRate = Convert.ToDecimal(dr["PriceRate"]);
                    result.Add(oget);
                }
                Conn.Close();
                sb.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public void Insertdata(StudentMasterDto oStddata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO Student (RFID,Initials,FirstName,LastName,Gender,DateOfBirth,Address,GuardianName,ContactNo,SchoolName,StudCategory,CreateDate) VALUES (@RFID,@Initials,@FirstName,@LastName,@Gender,@DateOfBirth,@Address,@GuardianName,@ContactNo,@SchoolName,@StudCategory,@CreateDate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@RFID", oStddata.RFID);
                cmd.Parameters.AddWithValue("@Initials", oStddata.Initials);
                cmd.Parameters.AddWithValue("@FirstName", oStddata.FirstName);
                cmd.Parameters.AddWithValue("@LastName", oStddata.LastName);
                cmd.Parameters.AddWithValue("@Gender", oStddata.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", oStddata.DateOfBirth);
                cmd.Parameters.AddWithValue("@Address", oStddata.Address);
                cmd.Parameters.AddWithValue("@GuardianName", oStddata.GuardianName);
                cmd.Parameters.AddWithValue("@ContactNo", oStddata.ContactNo);
                cmd.Parameters.AddWithValue("@SchoolName", oStddata.SchoolName);
                cmd.Parameters.AddWithValue("@StudCategory", oStddata.StudCategory);
                cmd.Parameters.AddWithValue("@CreateDate", oStddata.CreateDate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertPayment(StudentMasterDto oStddata, List<CourcesDto> olist)
        {
            foreach (var ol in olist)
            {
                
                try
                {
                    SqlConnection Conn = new SqlConnection(_Const);
                    SqlCommand cmd = new SqlCommand();

                    sb.Clear();
                    cmd = new SqlCommand("insert into Payment(StudentID,SubjectID,RegDate,PaymentYear,PaymentMonth,LecturerID,LastTransactionDate) values(@StudentID,@SubjectID,GETDATE(),'2021','01',@lecturerID,GETDATE())", Conn);
                    Conn.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@StudentID", oStddata.RFID);
                    cmd.Parameters.AddWithValue("@SubjectID", ol.SubjectID);
                    cmd.Parameters.AddWithValue("@lecturerID", ol.LectureID);
                    // cmd.Parameters.AddWithValue("@Payment", "false");
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            
        }
        public void InsertdataCourses(List<CourcesDto> oLecdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();
                for (int i = 0; oLecdata.Count > i; i++)
                {
                    sb.Clear();
                    cmd = new SqlCommand("INSERT INTO Cources (LectureID,SubjectCatID,SubjectID,RFID,PriceRate,RegistrationDate,PaymentStatus) VALUES (@LectureID,@SubjectCatID,@SubjectID,@RFID,@PriceRate,@RegistrationDate,@PaymentStatus)", Conn);
                    Conn.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@LectureID", oLecdata[i].LectureID);
                    cmd.Parameters.AddWithValue("@SubjectCatID", oLecdata[i].SubjectCatID);
                    cmd.Parameters.AddWithValue("@SubjectID", oLecdata[i].SubjectID);
                    cmd.Parameters.AddWithValue("@RFID", oLecdata[i].RFID);
                    cmd.Parameters.AddWithValue("@PriceRate", oLecdata[i].PriceRate);
                    cmd.Parameters.AddWithValue("@RegistrationDate", oLecdata[i].RegistrationDate);
                    cmd.Parameters.AddWithValue("@PaymentStatus", oLecdata[i].PaymentStatus);
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveStd(StudentMasterDto oStd)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE dbo.Student SET Initials='"+oStd.Initials+"',FirstName='"+oStd.FirstName+"',LastName='"+oStd.LastName+"',Gender='"+oStd.Gender+"',DateOfBirth='"+oStd.DateOfBirth+"',Address='"+oStd.Address+"',GuardianName='"+oStd.GuardianName+"',ContactNo='"+oStd.ContactNo+"',SchoolName='"+oStd.SchoolName+"',StudCategory='"+oStd.StudCategory+ "' WHERE RFID='" + oStd.RFID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@RFID", oStd.RFID);
                cmd.Parameters.AddWithValue("@Initials", oStd.Initials);
                cmd.Parameters.AddWithValue("@FirstName", oStd.FirstName);
                cmd.Parameters.AddWithValue("@LastName", oStd.LastName);
                cmd.Parameters.AddWithValue("@Gender", oStd.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", oStd.DateOfBirth);
                cmd.Parameters.AddWithValue("@Address", oStd.Address);
                cmd.Parameters.AddWithValue("@GuardianName", oStd.GuardianName);
                cmd.Parameters.AddWithValue("@ContactNo", oStd.ContactNo);
                cmd.Parameters.AddWithValue("@SchoolName", oStd.SchoolName);
                cmd.Parameters.AddWithValue("@StudCategory", oStd.StudCategory);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oStd.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<CourcesDto> GetCources()
        {
            List<CourcesDto> oEmlist = new List<CourcesDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT RFID,LectureID,SubjectCatID,SubjectID,PriceRate FROM [Cources]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CourcesDto oStd = new CourcesDto();
                    oStd.RFID = dr["RFID"].ToString();
                    oStd.LectureID = Convert.ToInt32(dr["LectureID"]);
                    oStd.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oStd.SubjectCatID = Convert.ToInt32(dr["SubjectCatID"]);
                    oStd.PriceRate = Convert.ToDecimal(dr["PriceRate"]);
                    oEmlist.Add(oStd);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }
        public void UpdatedataCourses(List<CourcesDto> oLecdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                List<CourcesDto> osub = new List<CourcesDto>();
                osub = GetCources();

                for (int i = 0; oLecdata.Count > i; i++)
                {
                    bool exists = osub.Any(x => x.SubjectID == oLecdata[i].SubjectID && x.SubjectCatID == oLecdata[i].SubjectCatID && x.LectureID == oLecdata[i].LectureID && x.RFID == oLecdata[i].RFID);

                    if(exists != false)
                    {
                        sb.Clear();
                        cmd = new SqlCommand("UPDATE Cources SET PriceRate='" + oLecdata[i].PriceRate + "' WHERE RFID='" + oLecdata[i].RFID + "' AND Cources.LectureID='" + oLecdata[i].LectureID + "' AND Cources.SubjectCatID='" + oLecdata[i].SubjectCatID + "' AND SubjectID='" + oLecdata[i].SubjectID + "'", Conn);
                        Conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@LectureID", oLecdata[i].LectureID);
                        cmd.Parameters.AddWithValue("@SubjectCatID", oLecdata[i].SubjectCatID);
                        cmd.Parameters.AddWithValue("@SubjectID", oLecdata[i].SubjectID);
                        cmd.Parameters.AddWithValue("@RFID", oLecdata[i].RFID);
                        cmd.Parameters.AddWithValue("@PriceRate", oLecdata[i].PriceRate);
                        cmd.ExecuteNonQuery();
                        Conn.Close();
                    }
                    else
                    {
                        sb.Clear();
                        cmd = new SqlCommand("INSERT INTO Cources (LectureID,SubjectCatID,SubjectID,RFID,PriceRate) VALUES (@LectureID,@SubjectCatID,@SubjectID,@RFID,@PriceRate)", Conn);
                        Conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@LectureID", oLecdata[i].LectureID);
                        cmd.Parameters.AddWithValue("@SubjectCatID", oLecdata[i].SubjectCatID);
                        cmd.Parameters.AddWithValue("@SubjectID", oLecdata[i].SubjectID);
                        cmd.Parameters.AddWithValue("@RFID", oLecdata[i].RFID);
                        cmd.Parameters.AddWithValue("@PriceRate", oLecdata[i].PriceRate);
                        cmd.ExecuteNonQuery();
                        Conn.Close();
                    }
                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteStd(String Stud)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM Student WHERE RFID='" + Stud + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@RFID", Stud);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(String StdName)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT RFID FROM [dbo.Student]");
                    sb.AppendLine(" WHERE RFID=@RFID");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("RFID", StdName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        LectureMasterDto result = new LectureMasterDto();
                        if (dr["RFID"] != null)
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

