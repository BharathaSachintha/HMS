using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HMS.Model;
using HMS.Service;

namespace HMS.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginService oEmpService = new LoginService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["result"] != "match")
            {
                Session.RemoveAll();
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
        public void InsertData()
        {
            LoginDto oData = new LoginDto();
            oData.UserName = txtUserName.Text.ToString();
            oData.Password = txtPassword.Text.ToString();
            string result= oEmpService.Login(oData);
            try
            {
                if (result == "match")
                {
                    string script = "alert(\"Login Succesful !\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    Session["User_name"] = txtUserName.Text;
                    Session["result"] = result;
                    Response.Redirect("~/pages/Dashboard.aspx");
                    
                    
                }
                else 
                {
                    txtUserName.Text = "";
                    string script = "alert(\"User Name or Password incorrect !\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            InsertData();
           
        }
    }
}