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
    public class UserRoleService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();
        public List<UserRoleDto> GetData()
        {
            List<UserRoleDto> oEmlist = new List<UserRoleDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT UserName,RealName,Password FROM [UserRole]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UserRoleDto oUser = new UserRoleDto();
                    oUser.UserName = dr["UserName"].ToString();
                    oUser.RealName = dr["RealName"].ToString();
                    oUser.Password = dr["Password"].ToString();
                    oEmlist.Add(oUser);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }

        public void Insertdata(UserRoleDto oUserdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO UserRole (UserName,RealName,Password) VALUES (@UserName,@RealName,@Password)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserName", oUserdata.UserName);
                cmd.Parameters.AddWithValue("@RealName", oUserdata.RealName);
                cmd.Parameters.AddWithValue("@Password", oUserdata.Password);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveHall(UserRoleDto UserRoleDto)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE UserRole SET RealName='" + UserRoleDto.RealName + "',Password='" + UserRoleDto.Password + "' WHERE UserName='" + UserRoleDto.UserName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@UserName", UserRoleDto.UserName);
                cmd.Parameters.AddWithValue("@RealName", UserRoleDto.RealName);
                cmd.Parameters.AddWithValue("@Password", UserRoleDto.Password);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteSubject(String UserName)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM UserRole WHERE UserName='" + UserName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(String UserName)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT UserName FROM [dbo.UserRole]");
                    sb.AppendLine(" WHERE UserName=@UserName");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("UserName", UserName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EmployeeMasterDto result = new EmployeeMasterDto();
                        if (dr["UserName"] != null)
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

