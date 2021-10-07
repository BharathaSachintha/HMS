using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HMS.Model;
using System.Data.SqlClient;

namespace HMS.Service
{
    public class HallMasterService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();
        public List<HallMasterDto> GetData()
        {
            List<HallMasterDto> oEmlist = new List<HallMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT HallName,HallDescription,StudentCapacity FROM [Hall]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    HallMasterDto oHall = new HallMasterDto();
                    oHall.HallName = dr["HallName"].ToString();
                    oHall.HallDescription = dr["HallDescription"].ToString();
                    oHall.StudentCapacity = dr["StudentCapacity"].ToString();
                    oEmlist.Add(oHall);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }

        public void Insertdata(HallMasterDto oHalldata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO Hall (HallName,HallDescription,StudentCapacity,CreateDate) VALUES (@HallName,@HallDescription,@StudentCapacity,@CreateDate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@HallName", oHalldata.HallName);
                cmd.Parameters.AddWithValue("@HallDescription", oHalldata.HallDescription);
                cmd.Parameters.AddWithValue("@StudentCapacity", oHalldata.StudentCapacity);
                cmd.Parameters.AddWithValue("@CreateDate", oHalldata.CreateDate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }
        public void SaveHall(HallMasterDto oHall)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE Hall SET HallDescription='" + oHall.HallDescription + "',StudentCapacity='" + oHall.StudentCapacity + "' WHERE HallName='" + oHall.HallName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@HallName", oHall.HallName);
                cmd.Parameters.AddWithValue("@HallDescription", oHall.HallDescription);
                cmd.Parameters.AddWithValue("@StudentCapacity", oHall.StudentCapacity);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oHall.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteSubject(String HallName)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM Hall WHERE HallName='" + HallName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@HallName", HallName);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(String HallName)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT HallName FROM [dbo.Hall]");
                    sb.AppendLine(" WHERE HallName=@HallName");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("HallName", HallName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EmployeeMasterDto result = new EmployeeMasterDto();
                        if (dr["HallName"] != null)
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

