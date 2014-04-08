using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Employees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init();
        }
    }
    void Init()
    {
        //year
        for (int i = -5; i < 6; i++)
        {
            string s=(DateTime.Today.Year + i).ToString();
            cboYear.Items.Add(s);
            
        }
        for (int i = 0; i < cboYear.Items.Count; i++)
        {
            string s=cboYear.Items[i].Text.ToString();
            if(s==DateTime.Today.Year.ToString()){
                cboYear.SelectedIndex = i;
                break;
            }
        }
            //month
            for (int i = 1; i < 13; i++)
            {
                cboMonth.Items.Add(i.ToString());
            }
            for (int i = 0; i < cboMonth.Items.Count; i++)
            {
                string s = cboMonth.Items[i].Text.ToString();
                if (s == DateTime.Today.Month.ToString())
                {
                    cboMonth.SelectedIndex = i;
                    break;
                }
            }
                //department
                GetDepart();
        //grid
        InitGrid();
    }
    void GetDepart()
    {
        //DataSet ds = new DataSet();
        //ds = DBHelper.SelectData("select * from department");
        //cboDepart.Items.Clear();
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cboDepart.Items.Add(ds.Tables[0].Rows[i]["departname"].ToString());
        //}
    }
    void InitGrid()
    {
        //DataSet ds = new DataSet();
        //ds = DBHelper.SelectData("select * from employees where 1=2");
        //this.rept.DataSource = ds.Tables[0].DefaultView;
        //rept.DataBind();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        RefreshEmp();
    }
    void RefreshEmp()
    {
        //DataSet ds = new DataSet();
        //ds = DBHelper.SelectData("select * from employees where emp_depart='" + cboDepart.SelectedItem.Text + "' and emp_state<>'已经离职'");
        //rept.DataSource = ds.Tables[0].DefaultView;
        //rept.DataBind();
    }
    protected void cboDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshEmp();
    }
    //protected void rept_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    string sDepart;
    //    if (e.CommandName.ToLower() == "viewcq")
    //    {
    //        if (Session["userDepart"] == null)
    //        {
    //            Response.Write("<script>window.open('Login.aspx','_blank')</script>");
    //            return;
    //        }
    //        Label l = new Label();
    //        l = (Label)rept.Items[e.Item.ItemIndex].FindControl("lblDepart");
    //        sDepart = l.Text;
    //        if(sDepart!=Session["userDepart"].ToString())
    //        {
    //            if (Session["userDepart"].ToString().ToLower() != "all")
    //            {
    //                Response.Write("<script>alert('您无权查看此部门的考勤')</script>");
    //                return;
    //            }
    //        }
    //        //<script>window.open('XXX.aspx','_blank')</script>
    //        string newPage="cq.aspx?year=" + this.cboYear.SelectedItem.Text + "&month=" + this.cboMonth.SelectedItem.Text + "&empDepart=" + cboDepart.SelectedItem.Text + "&empName=" +
    //            ((Label)rept.Items[e.Item.ItemIndex].FindControl("lblempName")).Text;
    //        if (Session["userName"] != null)
    //        {
    //            Response.Write("<script>window.open('" + newPage + "','_blank')</script>");
    //        }
    //        else
    //        {
            
    //            Response.Write("<script>window.open('Login.aspx','_blank')</script>");                
    //        }
            
    //    }
    //}
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            //lbluser.Text = Session["userName"].ToString();
            //lblDepart.Text = Session["userDepart"].ToString();
            //Timer1.Enabled = false;
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            Session["userName"] = null;
            Session["userDepart"] = null;
        }
    }
    protected void btnEmployees_Click(object sender, EventArgs e)
    {
        //if (lbluser.Text.Trim() == "")
        //{
        //    Response.Redirect("<script>window.open('Login.aspx','_blank')</script>");
        //}
        //else
        //{
        //    Response.Redirect("employees.aspx?kqer=" + lbluser.Text);
        //}
        
    }

    protected void btnProcessQJ_Click(object sender, EventArgs e)
    {
        string  iYear;
        string  iMonth;
        string dateF;
        string dateT;

        iYear = cboYear.Text;
        iMonth = cboMonth.Text;
        dateF = iYear + "-" + iMonth + "-1";
        dateT = iYear + "-" + iMonth + "-" +  DateTime.DaysInMonth(int.Parse(iYear),int.Parse(iMonth));
        string sql = "update attendance set remark='注释为：请假/放假',Abnormal=null where abqj=1 and fingerdate>='" + dateF + "' and fingerdate<='" + dateT + "'";
        DBHelper.ExcSql(sql);
        ClientScript.RegisterStartupScript(this.GetType(), "fdk", "<script>alert('请假注释成功!');</script>");
    }
    protected void btnManualFinger_Click(object sender, EventArgs e)
    {
        string iYear;
        string iMonth;
        string dateF;
        string dateT;

        iYear = cboYear.Text;
        iMonth = cboMonth.Text;
        dateF = iYear + "-" + iMonth + "-1";
        dateT = iYear + "-" + iMonth + "-" + DateTime.DaysInMonth(int.Parse(iYear), int.Parse(iMonth));
        string sql = "update attendance set remark='签纸卡',Abnormal=null from attendance,manualfinger where attendance.remark is null and not attendance.abnormal is null and manualfinger.mfnum=attendance.emp_no and attendance.fingerdate>='" + dateF + "' and attendance.fingerdate<='" + dateT + "'";
        DBHelper.ExcSql(sql);
        ClientScript.RegisterStartupScript(this.GetType(), "fdk", "<script>alert('签纸卡处理完成!');</script>");
    }
    protected void btnComment_Click(object sender, EventArgs e)
    {
        string iYear;
        string iMonth;
        string dateF;
        string dateT;

        iYear = cboYear.Text;
        iMonth = cboMonth.Text;
        dateF = iYear + "-" + iMonth + "-1";
        dateT = iYear + "-" + iMonth + "-" + DateTime.DaysInMonth(int.Parse(iYear), int.Parse(iMonth));
        string sql = "update attendance set remark='注释为：'+abnormalexplain,Abnormal=null where remark is null and not abnormalexplain is null and abnormalexplain<>'' and fingerdate>='" + dateF + "' and fingerdate<='" + dateT + "'";
        DBHelper.ExcSql(sql);
        ClientScript.RegisterStartupScript(this.GetType(), "fdk", "<script>alert('获得注释处理完成!');</script>");
    }
    void Process(string sSet,string sWhere)
    {
       
    }
}