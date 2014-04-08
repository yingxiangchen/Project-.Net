using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    bool CheckPwd(string userName, string Pwd)
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from userlistwebkq where username='" + userName + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            if(ds.Tables[0].Rows[0]["userpwd"].ToString()==Pwd)
            {
                Session["userDepart"] = ds.Tables[0].Rows[0]["viewdepart"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (CheckPwd(txtUser.Text.Trim(),txtPwd.Text ) == true)
        {
            Session["userName"] = txtUser.Text;
            Session["userPwd"] = txtPwd.Text;            
            lblErrInfo.Text = "登录成功";
            string s = Request.QueryString["frm"];
            if (s.Trim() != "")
            {
                Response.Redirect(s);
            }
            else
            {
                Response.Redirect("LoginS.aspx");
            }
        }
        else
        {
            lblErrInfo.Text = "用户名或密码错误，无法登录";
        }
    }
}