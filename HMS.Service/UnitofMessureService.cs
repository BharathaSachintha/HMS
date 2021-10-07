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
    public class UnitofMessureService
    {
        string _Const = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
        private StringBuilder sb = new StringBuilder();


        public List<UnitofMessureDto> GetData()
        {
            List<UnitofMessureDto> oUOMlist = new List<UnitofMessureDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT UomID, Major, Minor FROM [UnitofMessure]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UnitofMessureDto oUOM = new UnitofMessureDto();
                    oUOM.UomID = Convert.ToInt32(dr["UomID"].ToString());
                    oUOM.Major = dr["Major"].ToString();
                    oUOM.Minor = dr["Minor"].ToString();
                    oUOMlist.Add(oUOM);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oUOMlist;
        }
        public int GetLastUomID()
        {
            int results = 0;
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.AppendLine("SELECT TOP 1 * FROM UnitofMessure ORDER BY CreateDate Desc");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr["UomID"].Equals(DBNull.Value))
                    {
                        results = Convert.ToInt32(dr["UomID"]);
                    }
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return results;
        }
        public void Insert(UnitofMessureDto oUomData)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO UnitofMessure (UomID, Major, Minor, CreateDate) VALUES (@UomID,@Major,@Minor,@CreateDate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UomID", oUomData.UomID);
                cmd.Parameters.AddWithValue("@Major", oUomData.Major);
                cmd.Parameters.AddWithValue("@Minor", oUomData.Minor);
                cmd.Parameters.AddWithValue("@CreateDate", oUomData.CreateDate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(UnitofMessureDto oUom)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE UnitofMessure SET Major='" + oUom.Major + "', Minor='"+ oUom.Minor  + "' WHERE UomID='" + oUom.UomID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@UomID", oUom.UomID);
                cmd.Parameters.AddWithValue("@Major", oUom.Major);
                cmd.Parameters.AddWithValue("@Minor", oUom.Minor);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oUom.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int UOMID)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM UnitofMessure WHERE UomID='" + UOMID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@UomID", UOMID);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
