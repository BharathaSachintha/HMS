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
    public class LectureMasterService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();
        private StudentMasterService oSubjectMasterService = new StudentMasterService();

        public List<LectureMasterDto> GetData()
        {
            List<LectureMasterDto> oEmlist = new List<LectureMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT Title,Initials,FirstName,LastName,Address,NICNo,ContactNo,Email,LecturerRate FROM [Lecturer]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LectureMasterDto oLec = new LectureMasterDto();
                    oLec.Title = dr["Title"].ToString();
                    oLec.Initials = dr["Initials"].ToString();
                    oLec.FirstName = dr["FirstName"].ToString();
                    oLec.LastName = dr["LastName"].ToString();
                    oLec.Address = dr["Address"].ToString();
                    oLec.NICNo =Convert.ToInt32(dr["NICNo"].ToString());
                    oLec.ContactNo = dr["ContactNo"].ToString();
                    oLec.Email = dr["Email"].ToString();
                    oLec.Rate = Convert.ToDecimal(dr["LecturerRate"].ToString());
                    oEmlist.Add(oLec);
                }
                Conn.Close();
                sb.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }
        public List<SubjectMasterDto> GetSubject()
        {
            List<SubjectMasterDto> result = new List<SubjectMasterDto>();
            result.Add(new SubjectMasterDto { SubjectID = 0, getName = "-Select-" });
            result.AddRange(this.GetSubjects());

            return result;
        }
        public List<SubjectMasterDto> GetSubjects()
        {
            List<SubjectMasterDto> oEmlist = new List<SubjectMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT SubjectID,SubjectName FROM Subject");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SubjectMasterDto oEmp = new SubjectMasterDto();
                    oEmp.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oEmp.getName = dr["SubjectName"].ToString();
                    oEmlist.Add(oEmp);
                }
                Conn.Close();
                sb.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }
        public List<SubjectMasterDto> GetfilterSub(int subcat)
        {
            List<SubjectMasterDto> result = new List<SubjectMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT Subject.SubjectID,Subject.SubjectName,Subject.SubjectCategory,Subject.SubjectDiscription,SubjectCategory.SubjectCatName FROM [Subject] INNER JOIN SubjectCategory ON [Subject].SubjectCategory = SubjectCategory.SubjectCatID where SubjectCategory='" + subcat + "'");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();;
                cmd.Parameters.AddWithValue("@SubjectCategory", subcat);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SubjectMasterDto oget = new SubjectMasterDto();
                    oget.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oget.getCategory = dr["SubjectCatName"].ToString();
                    oget.getName = dr["SubjectName"].ToString();
                    oget.SubjectCatID = Convert.ToInt32(dr["SubjectCategory"]);
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
        public List<SubjectMasterDto> getlecture(int NIC)
        {
            List<SubjectMasterDto> result = new List<SubjectMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Clear();
                sb.Append("SELECT LecturesSubjects.SubjectCatID, LecturesSubjects.SubjectID, LecturesSubjects.SubjectName, LecturesSubjects.PriceRate, SubjectCategory.SubjectCatName FROM LecturesSubjects INNER JOIN SubjectCategory ON [LecturesSubjects].SubjectCatID = SubjectCategory.SubjectCatID WHERE LectureID='" + NIC + "'");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open(); ;
                cmd.Parameters.AddWithValue("@LectureID", NIC);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SubjectMasterDto oget = new SubjectMasterDto();
                    oget.SubjectCatID = Convert.ToInt32(dr["SubjectCatID"]);
                    oget.getCategory = dr["SubjectCatName"].ToString();
                    oget.getName = dr["SubjectName"].ToString();
                    oget.SubjectID = Convert.ToInt32(dr["SubjectID"]);
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

        public void Insertdata(LectureMasterDto oLecdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO Lecturer (Title,Initials,FirstName,LastName,Address,NICNo,ContactNo,Email,CreateDate,LecturerRate) VALUES (@Title,@Initials,@FirstName,@LastName,@Address,@NICNo,@ContactNo,@Email,@CreateDate,@LecturerRate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Title", oLecdata.Title);
                cmd.Parameters.AddWithValue("@Initials", oLecdata.Initials);
                cmd.Parameters.AddWithValue("@FirstName", oLecdata.FirstName);
                cmd.Parameters.AddWithValue("@LastName", oLecdata.LastName);
                cmd.Parameters.AddWithValue("@Address", oLecdata.Address);
                cmd.Parameters.AddWithValue("@NICNo", oLecdata.NICNo);
                cmd.Parameters.AddWithValue("@ContactNo", oLecdata.ContactNo);
                cmd.Parameters.AddWithValue("@Email", oLecdata.Email);
                cmd.Parameters.AddWithValue("@CreateDate", oLecdata.CreateDate);
                cmd.Parameters.AddWithValue("@LecturerRate", oLecdata.LecturerRate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertdataLecsub(List<LecturesSubjectsDto> oLecdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();
                for (int i = 0; oLecdata.Count > i; i++)
                {
                    sb.Clear();
                    cmd = new SqlCommand("INSERT INTO LecturesSubjects (LectureID,SubjectCatID,SubjectID,SubjectName,PriceRate) VALUES (@LectureID,@SubjectCatID,@SubjectID,@SubjectName,@PriceRate)", Conn);
                    Conn.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@LectureID", oLecdata[i].LectureID);
                    cmd.Parameters.AddWithValue("@SubjectCatID", oLecdata[i].SubjectCatID);
                    cmd.Parameters.AddWithValue("@SubjectID", oLecdata[i].SubjectID);
                    cmd.Parameters.AddWithValue("@SubjectName", oLecdata[i].SubjectName);
                    cmd.Parameters.AddWithValue("@PriceRate", oLecdata[i].PriceRate);
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveSub(LectureMasterDto oLec)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE dbo.Lecturer SET Title='"+oLec.Title+"',Initials='"+oLec.Initials+"', LastName='" + oLec.LastName + "',Address='" + oLec.Address + "',NICNo='"+oLec.NICNo+ "',ContactNo='"+oLec.ContactNo+ "',Email='"+oLec.Email+ "',LecturerRate='"+oLec.LecturerRate+"' WHERE FirstName='" + oLec.FirstName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@Title", oLec.Title);
                cmd.Parameters.AddWithValue("@Initials", oLec.Initials);
                cmd.Parameters.AddWithValue("@FirstName", oLec.FirstName);
                cmd.Parameters.AddWithValue("@LastName", oLec.LastName);
                cmd.Parameters.AddWithValue("@Address", oLec.Address);
                cmd.Parameters.AddWithValue("@NICNo", oLec.NICNo);
                cmd.Parameters.AddWithValue("@ContactNo", oLec.ContactNo);
                cmd.Parameters.AddWithValue("@Email", oLec.Email);
                cmd.Parameters.AddWithValue("@LecturerRate", oLec.LecturerRate);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oLec.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateataLecsub(List<LecturesSubjectsDto> oLecdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                List<LecturesSubjectsDto> osub = new List<LecturesSubjectsDto>();
                osub = oSubjectMasterService.GetList();

                for (int i = 0; oLecdata.Count > i; i++)
                {
                    bool exists = osub.Any(x => x.SubjectID == oLecdata[i].SubjectID && x.SubjectCatID == oLecdata[i].SubjectCatID && x.LectureID == oLecdata[i].LectureID);

                    if(exists != false)
                    {
                        sb.Clear();
                        cmd = new SqlCommand("UPDATE LecturesSubjects SET SubjectCatID='" + oLecdata[i].SubjectCatID + "',SubjectID='" + oLecdata[i].SubjectID + "',SubjectName='" + oLecdata[i].SubjectName + "',PriceRate='" + oLecdata[i].PriceRate + "' WHERE LectureID ='" + oLecdata[i].LectureID + "'", Conn);
                        Conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@LectureID", oLecdata[i].LectureID);
                        cmd.Parameters.AddWithValue("@SubjectCatID", oLecdata[i].SubjectCatID);
                        cmd.Parameters.AddWithValue("@SubjectID", oLecdata[i].SubjectID);
                        cmd.Parameters.AddWithValue("@SubjectName", oLecdata[i].SubjectName);
                        cmd.Parameters.AddWithValue("@PriceRate", oLecdata[i].PriceRate);
                        cmd.ExecuteNonQuery();
                        Conn.Close();
                    }
                    else
                    {
                        sb.Clear();
                        cmd = new SqlCommand("INSERT INTO LecturesSubjects (LectureID,SubjectCatID,SubjectID,SubjectName,PriceRate) VALUES (@LectureID,@SubjectCatID,@SubjectID,@SubjectName,@PriceRate)", Conn);
                        Conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@LectureID", oLecdata[i].LectureID);
                        cmd.Parameters.AddWithValue("@SubjectCatID", oLecdata[i].SubjectCatID);
                        cmd.Parameters.AddWithValue("@SubjectID", oLecdata[i].SubjectID);
                        cmd.Parameters.AddWithValue("@SubjectName", oLecdata[i].SubjectName);
                        cmd.Parameters.AddWithValue("@PriceRate", oLecdata[i].PriceRate);
                        cmd.ExecuteNonQuery();
                        Conn.Close();
                    }

                   
                    //else insert
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteSubject(String LecName)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM Lecturer WHERE FirstName='" + LecName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@FirstName", LecName);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(String LecName)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT FirstName FROM [dbo.Lecturer]");
                    sb.AppendLine(" WHERE FirstName=@FirstName");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("FirstName", LecName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        LectureMasterDto result = new LectureMasterDto();
                        if (dr["FirstName"] != null)
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

