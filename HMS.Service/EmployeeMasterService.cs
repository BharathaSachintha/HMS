using HMS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace HMS.Service
{
    public class EmployeeMasterService
    {

        string _Const = ConfigurationManager.ConnectionStrings["dbRuwan"].ConnectionString;
        private StringBuilder sb = new StringBuilder();


        public List<EmployeeMasterDto> GetData()
        {
            List<EmployeeMasterDto> oEmlist = new List<EmployeeMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT EmpID, EmployeeName FROM [EmployeeMaster]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EmployeeMasterDto oEmp = new EmployeeMasterDto();
                    oEmp.EmpID = Convert.ToInt32(dr["EmpID"].ToString());
                    oEmp.EmployeeName = dr["EmployeeName"].ToString();
                    oEmlist.Add(oEmp);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }

        public void Insertdata (EmployeeMasterDto oEmpdata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO EmployeeMaster (EmpID, EmployeeName, CreateDate) VALUES (@EmpID,@EmployeeName,@CreateDate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmpID", oEmpdata.EmpID);
                cmd.Parameters.AddWithValue("@EmployeeName", oEmpdata.EmployeeName);
                cmd.Parameters.AddWithValue("@CreateDate", oEmpdata.CreateDate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveEmp(EmployeeMasterDto oEmp)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE EmployeeMaster SET EmployeeName='" + oEmp.EmployeeName + "' WHERE EmpID='" + oEmp.EmpID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@EmpID", oEmp.EmpID);
                cmd.Parameters.AddWithValue("@EmployeeName", oEmp.EmployeeName);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oEmp.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteEmployee(int EmpID)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM EmployeeMaster WHERE EmpID='" + EmpID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(int EmpID)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT EmpID FROM [EmployeeMaster]");
                    sb.AppendLine(" WHERE EmpID=@EmpID");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("EmpID", EmpID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EmployeeMasterDto result = new EmployeeMasterDto();
                        if (dr["EmpID"] != null)
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
