using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyShop_myShop : BLL.JudgeUserLogon 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkUserLogoned();
    }
    void checkUserLogoned()
    {
        bool blnX=BLL.UserBll.CheckUserLogoned();        
        btnLogout.Visible = blnX;
        if (blnX) { lblUserName.Text = "欢迎您！" + Session["userName"].ToString(); }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Redirect("../userLogon.aspx");
    }
}