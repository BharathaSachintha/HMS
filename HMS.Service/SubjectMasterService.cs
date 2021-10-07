using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace HMS.Service
{
    
    public class SubjectMasterService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();

        public List<SubjectMasterDto> GetData()
        {
            List<SubjectMasterDto> oEmlist = new List<SubjectMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT Subject.SubjectID,Subject.SubjectName,Subject.SubjectCategory,Subject.SubjectDiscription,SubjectCategory.SubjectCatName FROM [Subject] INNER JOIN SubjectCategory ON [Subject].SubjectCategory = SubjectCategory.SubjectCatID");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SubjectMasterDto oEmp = new SubjectMasterDto();
                    oEmp.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    oEmp.getName = dr["SubjectName"].ToString();
                    oEmp.getCategory = dr["SubjectCatName"].ToString();
                    oEmp.SubjectCatID = Convert.ToInt32(dr["SubjectCategory"]);
                    oEmp.getDescription = dr["SubjectDiscription"].ToString();
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
        public List<SubjectMasterDto> GetSubCat()
        {
            List<SubjectMasterDto> result = new List<SubjectMasterDto>();
            result.Add(new SubjectMasterDto { SubjectCatID = 0, SubjectCatName = "-Select-" });
            result.AddRange(this.GetSubCats());

            return result;
        }
        public List<SubjectMasterDto> GetSubCate()
        {
            List<SubjectMasterDto> result = new List<SubjectMasterDto>();
            result.Add(new SubjectMasterDto { SubjectCatID = 0, SubjectCatName = "-ALL-" });
            result.AddRange(this.GetSubCats());

            return result;
        }
        public List<SubjectMasterDto> GetSubCats()
        {
            List<SubjectMasterDto> oEmlist = new List<SubjectMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT SubjectCatID,SubjectCatName FROM SubjectCategory");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SubjectMasterDto oEmp = new SubjectMasterDto();
                    oEmp.SubjectCatID = Convert.ToInt32(dr["SubjectCatID"]);
                    oEmp.SubjectCatName = dr["SubjectCatName"].ToString();
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
        public int GetLastSubCat()
        {
            int lastcatid = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);

                sb.Clear();
                sb.Append("SELECT MAX(SubjectCatID) as SubjectCatIDs FROM [SubjectCategory]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.Clear();
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lastcatid = Convert.ToInt32(dr["SubjectCatIDs"]) + 1;
                }
                Conn.Close();
                sb.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastcatid;
        }
        public void insetsubcat(SubjectMasterDto oCat)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO SubjectCategory (SubjectCatID,SubjectCatName) VALUES (@SubjectCatID,@SubjectCatName)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@SubjectCatID", oCat.SubjectCatID);
                cmd.Parameters.AddWithValue("@SubjectCatName", oCat.SubjectCatName);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertdata(SubjectMasterDto oEmpdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO Subject (SubjectName,SubjectCategory,SubjectDiscription,CreateDate) VALUES (@SubjectName,@SubjectCategory,@SubjectDiscription,@CreateDate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@SubjectName", oEmpdata.getName);
                cmd.Parameters.AddWithValue("@SubjectCategory", oEmpdata.getCategory);
                cmd.Parameters.AddWithValue("@SubjectDiscription", oEmpdata.getDescription);
                cmd.Parameters.AddWithValue("@CreateDate", oEmpdata.CreateDate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveSub(SubjectMasterDto oEmp)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE dbo.Subject SET SubjectDiscription='" + oEmp.getDescription + "',SubjectCategory='"+oEmp.getCategory+ "' WHERE SubjectName='" + oEmp.getName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@SubjectName", oEmp.getName);
                cmd.Parameters.AddWithValue("@SubjectCategory", oEmp.getCategory);
                cmd.Parameters.AddWithValue("@SubjectDiscription", oEmp.getDescription);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oEmp.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteSubject(String SubName)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM Subject WHERE SubjectName='" + SubName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@SubjectName", SubName);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(String SubName)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT SubjectName FROM [dbo.Subject]");
                    sb.AppendLine(" WHERE SubName=@SubjectName");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("SubjectName", SubName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EmployeeMasterDto result = new EmployeeMasterDto();
                        if (dr["SubName"] != null)
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

