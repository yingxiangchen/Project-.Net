using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paiban_NPaiban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepart();
        }
    }
    void BindDepart()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from department");
        cboDepart.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            cboDepart.Items.Add("请选择");
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
        this.repAllEmpForDepart.DataSource = ds.Tables[0];
        this.repAllEmpForDepart.DataBind();
    }
    
    void ShowEmp()
    {
        lblCountEmp.Text = "";
        if (txtDateF.Text.Trim().Equals("") || txtDateT.Text.Trim().Equals(""))
        {
            lblErrInfo.Text = "请选择日期";
            return;
        }
        TimeSpan s = Convert.ToDateTime(txtDateT.Text) - Convert.ToDateTime(txtDateF.Text);
        if (s.Days < 5)
        {
            initGrid();
            lblErrInfo.Text = "排班日期间隔过短（不能小于一周）";
            return;
        }
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from employees where emp_depart='" + cboDepart.SelectedItem.Text + "' and emp_state<>'离职有薪' and emp_state<>'已经离职' and " +
            " emp_no not in(select empnum as emp_no from employeeclass where empdepart='" + cboDepart.SelectedItem.Text +
            "' and ((datefrom<='" + txtDateF.Text + "' and dateto>='" + txtDateF.Text + "') or (datefrom >='" + txtDateF.Text + "' and datefrom<='" + txtDateT.Text + "'))) order by emp_position");
        this.repAllEmpForDepart  .DataSource = ds.Tables[0].DefaultView;
        repAllEmpForDepart.DataBind();
        lblCountEmp.Text = "共有 " + ds.Tables[0].Rows.Count + " 名员工还未排班";
        lblErrInfo.Text = "";
        //DisableDateChange();
    }
    protected void cboDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowEmp();
    }
}