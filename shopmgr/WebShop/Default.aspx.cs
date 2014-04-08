using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default :System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            lblUsername.Text = Session["username"].ToString();
        }
        else
        {
            lblUsername.Text =null;
        }
    }
    
    protected void btnLogon_Click(object sender, EventArgs e)
    {
        Response.Redirect("userLogon.aspx");
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        Response.Redirect("userLogin.aspx");
    }
}