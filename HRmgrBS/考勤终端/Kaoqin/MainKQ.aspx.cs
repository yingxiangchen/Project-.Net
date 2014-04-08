using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class MainKQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDepartList();
            initGrid();
            LoadYearandMonth();
        }
    }
    void BindEmp(string empName="",string empNum="")
    {
        string dateF;
        string dateT;
        //string empName = Request.QueryString["empName"];
        string empDepart = cboDepart.SelectedItem.Text; //Request.QueryString["empDepart"];
        if (empDepart == "请选择")
        {
            empDepart = "";
        }
        string syear = cboYear.SelectedItem.Text; //Request.QueryString["year"];
        string smonth = cboMonth.SelectedItem.Text; //Request.QueryString["month"];
        string sql;        
        dateF = syear + "/" + smonth + "/1";
        dateT = syear + "/" + smonth + "/" + DateTime.DaysInMonth(Convert.ToInt32(syear), Convert.ToInt32(smonth));
        if (optByDepart.Checked == true)
        {

            sql = "Select distinct emp_no, emp_name,empPosition,department,AtualAttn,sum(attn) as atn from attendance where  fingerdate>='" + dateF + "' and fingerdate<='" + dateT +
                  "' and department like '" + empDepart + "%' and emp_name like '" + empName + "%' group by emp_no,emp_name,empposition,department,AtualAttn order by department, emp_no";

        }
        else
        {
            sql = "...";
        }
       
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData(sql);

        rptEmp.DataSource = ds.Tables[0].DefaultView;
        rptEmp.DataBind();
        lblEmpcount.Text = "共 " + ds.Tables[0].Rows.Count + " 名员工";
    }
    
    
    
    void LoadDepartList()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from department");        
        cboDepart.Items.Clear();
        cboDepart.Items.Add("请选择");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["Departname"].ToString().Trim() != "行政部" && ds.Tables[0].Rows[i]["Departname"].ToString().Trim()!="总经办")
            {
                cboDepart.Items.Add(ds.Tables[0].Rows[i]["Departname"].ToString());
            }
            
        }
    }
    void initGrid()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from attendance where 1=2");
        rptEmp.DataSource = ds.Tables[0];
        rptEmp.DataBind();
       
    }
    void LoadYearandMonth()
    {
        //year
        cboYear.Items.Clear();
        for (int i = -5; i < 6; i++)
        {
            string s = (DateTime.Today.Year + i).ToString();
            cboYear.Items.Add(s);

        }
        for (int i = 0; i < cboYear.Items.Count; i++)
        {
            string s = cboYear.Items[i].Text.ToString();
            if (s == DateTime.Today.Year.ToString())
            {
                cboYear.SelectedIndex = i;
                break;
            }
        }
        //month
        cboMonth.Items.Clear();
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
    }
    protected void optByDepart_CheckedChanged(object sender, EventArgs e)
    {
        if (optByDepart.Checked == true)
        {
            lbld.Visible = true;
            cboDepart.Visible = true;
            lblg.Visible = false;
            btnWorkGroup.Visible = false;
        }
        
    }
    protected void optByWorkGroup_CheckedChanged(object sender, EventArgs e)
    {
        if (optByWorkGroup.Checked == true)
        {
            lbld.Visible = false;
            cboDepart.Visible = false;
            lblg.Visible = true;
            btnWorkGroup.Visible = true;
        }
    }
    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        
    }
    
    
    protected void cboDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        initGrid();
       
        BindEmp();
        
    }
   
    
    protected void txtExplain_TextChanged(object sender, EventArgs e)
    {
        Response.Write( sender.ToString());
    }

    protected void rep_DataBinding(object sender, EventArgs e)
    {
        
    }
    protected void rep_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        
    }
    protected void btnWorkGroup_Click(object sender, EventArgs e)
    {

    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        initGrid();
        BindEmp(txtName.Text.Trim());
    }

    protected void rptEmp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if (e.CommandName == "view") {            
            string empNum;
            string empName;
            string empDepart;
            string empPosition;
            string AttnDay;
            string url;
            string dateF;
            string dateT;
            string syear = cboYear.SelectedItem.Text; 
            string smonth = cboMonth.SelectedItem.Text; 
            empNum = ((Label)e.Item.FindControl("empNum")).Text;
            empName = ((Label)e.Item.FindControl("empName")).Text;
            empPosition = ((Label)e.Item.FindControl("empPosition")).Text;
            empDepart = this.cboDepart.SelectedItem.Text;
            AttnDay = ((Label)e.Item.FindControl("attn")).Text;
            //检查实际出勤天数  
            dateF = syear + "/" + smonth + "/1";
            dateT = syear + "/" + smonth + "/" + DateTime.DaysInMonth(Convert.ToInt32(syear), Convert.ToInt32(smonth)); 
            string actulattn = ((TextBox)e.Item.FindControl("txtActulAttn")).Text.Trim();
            if (actulattn == "" || isNumber(actulattn) == false)
            {
                //ClientScript.RegisterStartupScript(GetType(), "x", "<script>promptandforward('请先输入实际出勤天数，必须为数字!')</script>");
                //return;
                actulattn = AttnDay;
                ((TextBox)e.Item.FindControl("txtActulAttn")).Text = AttnDay;
            }
            //保存实际出勤天数
            if (actulattn != "")
            {
                DBHelper.ExcSql("update attendance set AtualAttn=" + actulattn + " where emp_no=" + empNum + " and fingerdate>='" + dateF + "' and fingerdate <='" + dateT + "'");
            }
            ((Button)e.Item.FindControl("btnView")).Text = "=> 查看考勤";
            url = "UbnormalKQ.aspx?" + "empNum=" + empNum + "&empName=" + empName + "&empPosition=" + empPosition + "&empDepart=" + empDepart + "&attn=" + AttnDay + "&year=" + cboYear.Text + "&month=" + cboMonth.Text  ;
            //Response.Write("<script>openw('" + url + "')</script>");
            ClientScript.RegisterStartupScript(GetType(), "a", "<script>openw('" + url + "')</script>");
        }
        
        
    }
    bool isNumber(string sNum)
    {
        try
        {
            Convert.ToDouble(sNum);
            return true;
        }
        catch
        {
            return false;
        }
    }
    void ShowkqData(string empNum)
    {

    }
    protected void rptEmp_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
    }
    void ShowEmpKQ(Repeater rpt, string empNum = "")
    {
        try
        {
            //string empNum;
            string dateF;
            string dateT;
            //string empDepart = cboDepart.SelectedItem.Text; //Request.QueryString["empDepart"];
            string syear = cboYear.SelectedItem.Text; //Request.QueryString["year"];
            string smonth = cboMonth.SelectedItem.Text; //Request.QueryString["month"];
            string sql;
            DataSet ds = new DataSet();

            dateF = syear + "/" + smonth + "/1";
            dateT = syear + "/" + smonth + "/" + DateTime.DaysInMonth(Convert.ToInt32(syear), Convert.ToInt32(smonth));            
            sql = "select * from attendance where emp_no=" + empNum + " and fingerdate>='" + dateF + "' and fingerdate<='" + dateT + "'";
            ds = DBHelper.SelectData(sql);
            rpt.DataSource = ds.Tables[0];
            rpt.DataBind();
            //rpt.Visible = false;

        }
        catch { }
    }

    protected void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEmp();
    }
    protected void cboYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEmp();
    }
}