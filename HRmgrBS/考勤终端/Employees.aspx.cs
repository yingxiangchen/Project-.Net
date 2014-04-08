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
            initGrid();
            BindDepart();
        }
    }
    void LoadList(string empDepart, string empName,string empNum)
    {
        DataSet ds = new DataSet();
        string sql;
        string sNotIncludLeave;

        if (chkIncludLeave.Checked)
        {
            sNotIncludLeave = "";
        }
        else
        {
            sNotIncludLeave = " and emp_state<>'离职有薪' and emp_state<>'已经离职'";
        }
        if (empNum.Trim() != "")
        {
            sql = "select * from employees where emp_depart like '" + empDepart + "%' and emp_name like '" + empName + "%' and emp_no=" + empNum + sNotIncludLeave ;
        }
        else
        {
            sql = "select * from employees where  emp_depart like '" + empDepart + "%' and emp_name like '" + empName + "%'" + sNotIncludLeave ;
        }
        ds = DBHelper.SelectData(sql);        
        this.Repeater1.DataSource = ds.Tables[0].DefaultView ;
        this.Repeater1.DataBind();
        lblCountemp.Text = "共计 " + ds.Tables[0].Rows.Count.ToString() + " 名职员";
    }
    void BindDepart()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from department");
        cboDepart.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            cboDepart.Items.Add("不限");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cboDepart.Items.Add(ds.Tables[0].Rows[i]["DepartName"].ToString());
            }
        }
        initGrid();
    }
    void initGrid()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from employees where 1=2");
        this.Repeater1  .DataSource = ds.Tables[0];
        this.Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        string empDepart;
        if (cboDepart.SelectedIndex <= 0)
        {
            empDepart = "";
        }
        else
        {
            empDepart = cboDepart.SelectedItem.Value;
        }
        if (!txtNum.Text.Equals(""))
        {
            if (!isNum(txtNum.Text))
            {
                Response.Write("<script>alert('员工编号必须为数字。');</script>");
                return;
            }
        }
        LoadList(empDepart, txtName.Text.Trim(),txtNum.Text.Trim());
    }
    protected void btnNewEmp_Click(object sender, EventArgs e)
    {

    }
    bool isNum(string Num)
    {
        try
        {
            int.Parse(Num);
            return true;
        }
        catch
        {
            return false;
        }
    }
}