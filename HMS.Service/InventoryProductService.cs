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
    public class InventoryProductService
    {

        string _Const = ConfigurationManager.ConnectionStrings["HMS"].ConnectionString;
        private StringBuilder sb = new StringBuilder();


        public List<InvProductDto> GetData()
        {
            List<InvProductDto> oEmlist = new List<InvProductDto>();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("SELECT ProductID, ProductName FROM [InventoryProducts]");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    InvProductDto oinv = new InvProductDto();
                    oinv.ProductID = dr["ProductID"].ToString();
                    oinv.ProductName = dr["ProductName"].ToString();
                    oEmlist.Add(oinv);
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }
        public UnitofMessureDto GetUoms(string PID)
        {
            UnitofMessureDto oEmlist = new UnitofMessureDto();
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                sb.Append("select [UnitofMessure].Major, [UnitofMessure].Minor from [UnitofMessure] Inner join [InventoryProducts] ON [InventoryProducts].UomID = UnitofMessure.UomID where InventoryProducts.ProductID ='" + PID + "'");

                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, Conn);
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    oEmlist.Major = dr["Major"].ToString();
                    oEmlist.Minor = dr["Minor"].ToString();
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oEmlist;
        }
        public void Insertdata(InvProductDto oInv)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("INSERT INTO InventoryProducts (ProductID, ProductName, UOMID, CreateDate) VALUES (@ProductID,@ProductName,@UOMID,@CreateDate)", Conn);
                Conn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductID", oInv.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", oInv.ProductName);
                cmd.Parameters.AddWithValue("@UomID", oInv.UomID);
                cmd.Parameters.AddWithValue("@CreateDate", oInv.CreateDate);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(InvProductDto oInv)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("UPDATE InventoryProducts SET ProductName='" + oInv.ProductName + "',UomID='" + oInv.UomID + "'  WHERE ProductID='" + oInv.ProductID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@ProductID", oInv.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", oInv.ProductName);
                cmd.Parameters.AddWithValue("@UomID", oInv.UomID);
                cmd.Parameters.AddWithValue("@ModifiedDateTime", oInv.ModifiedDateTime);
                cmd.ExecuteNonQuery();
                Conn.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int PID)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);
                SqlCommand cmd = new SqlCommand();

                sb.Clear();
                cmd = new SqlCommand("DELETE FROM InventoryProducts WHERE ProductID='" + PID + "'", Conn);

                Conn.Open();
                cmd.Parameters.AddWithValue("@ProductID", PID);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckAvailability(string PID)
        {
            bool results = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_Const))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT ProductID FROM [InventoryProducts]");
                    sb.AppendLine(" WHERE ProductID=@ProductID");

                    string query = sb.ToString();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("ProductID", PID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        InvProductDto result = new InvProductDto();
                        if (dr["ProductID"] != null)
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
