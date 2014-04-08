using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAbnormal_Click(object sender, EventArgs e)
    {
        ifrm.Src = "mainkq.aspx";
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        
    }
    protected void btnProcessExplain_Click(object sender, EventArgs e)
    {
        
        
    }

  
    
    protected void mnu_MenuItemClick(object sender, MenuEventArgs e)
    {
        switch (e.Item.Value.ToLower())
        {
            case "turnclass"://员工排班
                ifrm.Src = "/paiban/Paiban.aspx";
                break;
            case "classtime"://班次及时间设置
                break;
            case "newpaiban":
                ifrm.Src = "/paiban/npaiban.aspx";
                break;
            case "kqrrdmgr"://考勤记录管理
                if (Session["UserName"] != null)
                {
                    if (Session["UserName"].ToString().ToLower() == "administrator")
                    {
                        ifrm.Src = "/kaoqin/upload.aspx";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "fd", "<script>alert('你没有足够的权限！');</script>");
                    }
                }
                else
                {
                    ifrm.Src = "/login/Login.aspx?frm=/kaoqin/upload.aspx";
                }
                
                break;
            case "abrkqrrdmgr"://考勤异常处理
                ifrm.Src = "Kaoqin/MainKQ.aspx";
                break;
            case "kqsummary":
                ifrm.Src = "/kaoqin/KQSummary.aspx";
                break;
            case "abrkqresults":
                if (Session["UserName"] != null)
                {
                    if (Session["UserName"].ToString().ToLower() == "administrator")
                    {
                        ifrm.Src = "AbnormalProcess.aspx";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "fd", "<script>alert('你没有足够的权限！');</script>");
                    }
                }
                else
                {
                    ifrm.Src = "/login/Login.aspx?frm=../AbnormalProcess.aspx";
                }
                break;
            case "empdata"://员工资料
                CheckAccess("Employees.aspx");
                break;
            case "newemp"://新进员工
                break;
            case "manualfinger":
                CheckAccess("/manualfinger/ManualFingerList.aspx");
                break;
        }
    }
    void CheckAccess(string PageForward)
    {
        if (Session["UserName"] != null)
        {
            if (Session["UserName"].ToString().ToLower() == "administrator")
            {
                ifrm.Src = PageForward;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "fd", "<script>alert('你没有足够的权限！');</script>");
            }
        }
        else
        {
            ifrm.Src = "/login/Login.aspx?frm=../" + PageForward;
        }
    }
}