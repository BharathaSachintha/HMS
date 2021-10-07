using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMS
{
    public partial class LoginMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //PageLoad();
            }
        }

        private void PageLoad()
        {
            Response.Redirect("~/Pages/Dashboard.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            PageLoad();
        }
    }
}