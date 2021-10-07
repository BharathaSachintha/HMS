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
    public class HallAllocationMasterService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        private StringBuilder sb = new StringBuilder();
        public List<HallAllocationMasterDto> GetData()
        {
            List<HallAllocationMasterDto> oEmlist = new List<HallAllocationMasterDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT HallID,ClassID,SceduleDate,StartTime,EndTime FROM [HallAllocation]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    HallAllocationMasterDto oHalla = new HallAllocationMasterDto();
                    oHalla.HallID = dr["HallID"].ToString();
                    oHalla.ClassID = dr["ClassID"].ToString();
                    oHalla.ScheduleDate =Convert.ToDateTime(dr["SceduleDate"].ToString());
                    oHalla.StartTime = dr["StartTime"].ToString();
                    oHalla.EndTime = dr["EndTime"].ToString();
                    oEmlist.Add(oHalla);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }

        public void Insertdata(HallAllocationMasterDto oHalladata)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO HallAllocation (HallID,ClassID,SceduleDate,StartTime,EndTime,CreateDate) VALUES (@HallID,@ClassID,@SceduleDate,@StartTime,@EndTime,GETDATE())", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@HallID", oHalladata.HallID);
                cmd.Parameters.AddWithValue("@ClassID", oHalladata.ClassID);
                cmd.Parameters.AddWithValue("@SceduleDate", oHalladata.ScheduleDate);
                cmd.Parameters.AddWithValue("@StartTime", oHalladata.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", oHalladata.EndTime);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveHalla(HallAllocationMasterDto oHalla)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE HallAllocation SET ClassID='" + oHalla.ClassID + "',SceduleDate='" + oHalla.ScheduleDate+"',StartTime='"+oHalla.StartTime+"',EndTime='"+oHalla.EndTime+"' WHERE HallName='" + oHalla.HallID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@HallID", oHalla.HallID);
                cmd.Parameters.AddWithValue("@ClassID", oHalla.ClassID);
                cmd.Parameters.AddWithValue("@ScheduleDate", oHalla.ScheduleDate);
                cmd.Parameters.AddWithValue("@StartTime", oHalla.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", oHalla.EndTime);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oHalla.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteSubject(String HallAName)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM HallAllocation WHERE HallID='" + HallAName + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@HallID", HallAName);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(String HallAName)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT HallID FROM [dbo.HallAllocation]");
                    sb.AppendLine(" WHERE HallID=@HallID");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("HallID", HallAName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EmployeeMasterDto result = new EmployeeMasterDto();
                        if (dr["HallID"] != null)
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
        
        public List<HallAllocationMasterDto> selectHall()
        {
            List<HallAllocationMasterDto> result = new List<HallAllocationMasterDto>();
            result.Add(new HallAllocationMasterDto { HallID = "0", HallName = "-select-" });
            result.AddRange(this.SelectHalls());

            return result;
        }
        public List<HallAllocationMasterDto> selectClass()
        {
            List<HallAllocationMasterDto> result = new List<HallAllocationMasterDto>();
            result.Add(new HallAllocationMasterDto { ClassID = "0", ClassName = "-select-" });
            result.AddRange(this.selectClasss());

            return result;
        }
        public List<HallAllocationMasterDto> selectClasss()
        {
            List<HallAllocationMasterDto> result = new List<HallAllocationMasterDto>();

            SqlConnection Conn = new SqlConnection(_Const);
            sb.Clear();
            sb.Append("select ClassID,ClassCode from Class");
            string quary = sb.ToString();
            SqlCommand cmd = new SqlCommand(quary, Conn);
            Conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                HallAllocationMasterDto oHall = new HallAllocationMasterDto();
                oHall.ClassID = dr["ClassID"].ToString();
                oHall.ClassName = dr["ClassCode"].ToString();
                result.Add(oHall);
            }
            Conn.Close();

            return result;

        }
        public List<HallAllocationMasterDto> SelectHalls()
        {
            List<HallAllocationMasterDto> result = new List<HallAllocationMasterDto>();

            SqlConnection Conn = new SqlConnection(_Const);
            sb.Clear();
            sb.Append("select HallID,HallName from Hall");
            string quary = sb.ToString();
            SqlCommand cmd = new SqlCommand(quary, Conn);
            Conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                HallAllocationMasterDto oHall = new HallAllocationMasterDto();
                oHall.HallID = dr["HallID"].ToString();
                oHall.HallName = dr["HallName"].ToString();
                result.Add(oHall);
            }
            Conn.Close();

            return result;

        }
    }

}

