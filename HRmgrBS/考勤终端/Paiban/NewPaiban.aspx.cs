using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NewPaiban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDateT.Text = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
            txtDateF.Text = txtDateT.Text;
            BindDepart();
            initGrid();
        }
    }
    void initGrid()
    {
            DataSet ds = new DataSet();
            ds = DBHelper.SelectData("select * from employees where 2>3");
            repNewPB.DataSource = ds.Tables[0].DefaultView;
            repNewPB.DataBind();
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
    }
    protected void cboDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowEmp();
    }
    void ShowEmp()
    {
        lblCountEmp.Text = "";
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
        repNewPB.DataSource = ds.Tables[0].DefaultView;
        repNewPB.DataBind();
        lblCountEmp.Text = "共有 " + ds.Tables[0].Rows.Count + " 名员工还未排班";
        lblErrInfo.Text = "";
        DisableDateChange();
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sBan="";
        string sUser;
        if (txtDateF.Text.Trim() == "" || txtDateT.Text.Trim() == "")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "a", "<script>alert('请先输入日期！');</script>");
            txtDateF.Focus();
        }
        //user
        if (Session["userName"] != null)
        {
            sUser = Session["userName"].ToString();
        }
        else
        {
            sUser = "";
        }
        foreach (RepeaterItem ri in repNewPB.Items)
        {
            //班次判断

            if (((RadioButton)ri.FindControl("rbZaoban")).Checked == true)
            {
                sBan = "早班";
            }
            else if (((RadioButton)ri.FindControl("rbZhongban")).Checked == true)
            {
                sBan = "中班";
            }
            else if (((RadioButton)ri.FindControl("rbWanban")).Checked == true)
            {
                sBan = "晚班";
            }            
            else
            {
                sBan = "";
            }
            //保存分班
            if (sBan != "")
            {
                DBHelper.ExcSql("insert into employeeclass(empdepart,empnum,empname,datefrom,dateto,empclass,updateby,updatetime) values('" +
                    ((Label)ri.FindControl("lblempDepart")).Text + "','" + ((Label)ri.FindControl("lblempNo")).Text + "','" +
                    ((Label)ri.FindControl("lblempName")).Text + "','" + txtDateF.Text.Trim() + "','" + txtDateT.Text.Trim() + "','" + sBan + "','" + sUser + "','" + DateTime.Now + "')");
            }

            //Console.WriteLine( ri.DataItem.ToString());
        }
        
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "a", "<script>alert('排班成功！');</script>");
        ShowEmp();
        EnableDateChange();
    }
    protected void txtDateF_TextChanged(object sender, EventArgs e)
    {

        ShowEmp();
    }
    protected void txtDateT_TextChanged(object sender, EventArgs e)
    {
        ShowEmp();
    }
    protected void repNewPB_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void btnRefreshEmp_Click(object sender, EventArgs e)
    {
        ShowEmp();
    }
   
    void DisableDateChange()
    {
        txtDateF.Enabled = false;
        txtDateT.Enabled = false;
    }
    void EnableDateChange()
    {
        txtDateF.Enabled = true;
        txtDateT.Enabled = true;
    }
   
}