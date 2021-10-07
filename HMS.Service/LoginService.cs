using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using HMS.Model;
using System.Data;

namespace HMS.Service
{
    public class LoginService
    {
        string _Const = ConfigurationManager.ConnectionStrings["dbRuwana"].ConnectionString;
        public string Login(LoginDto oData)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_Const);

                string quary =("Select * from UserRole where UserName= @username AND Password=@password");

                using (SqlDataAdapter adp = new SqlDataAdapter(quary, Conn))
                {
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@username", oData.UserName));
                    adp.SelectCommand.Parameters.Add(new SqlParameter("@password", oData.Password)); 
                    DataTable table = new DataTable();
                    adp.Fill(table);
                    int number_of_rows = table.Rows.Count;
                    if (number_of_rows == 0)
                    {
                        return "User Name OR Password Incorect !";
                    }
                       
                    else
                    {
                        return "match";
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
