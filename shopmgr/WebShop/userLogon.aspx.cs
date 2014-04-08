using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userLogon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        lblInfo.Text = BLL.UserBll.UserLogon(txtuserName.Text.Trim(), txtUserPwd.Text, null) ;
        if (lblInfo.Text == "已登录")
        {
            Response.Redirect("~/myshop/myShop.aspx");
        }
    }
   
}