using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDateF.Text = DateTime.Today.Year + "-" + DateTime.Today.Month + "-01";
            txtDateT.Text = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
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
        init();
    }
    void init()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from employeeclass where datefrom='" + txtDateF.Text + "' and dateto='" + txtDateT.Text + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            repPB.DataSource = ds.Tables[0].DefaultView;
            repPB.DataBind();
        }
        else
        {
            ds = DBHelper.SelectData("select * from employeeclass where 1=2");
            repPB.DataSource = ds.Tables[0].DefaultView;
            repPB.DataBind();
        }
    }

   
    protected void cboDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        refreshData();
    }
    void refreshData()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from EmployeeClass where ((datefrom<='" + 
            txtDateF.Text + "' and dateto>='" + txtDateT.Text + "') or (datefrom>='" + 
            txtDateF.Text + "' and datefrom<='" + txtDateT.Text + "')) and empdepart='" + cboDepart.SelectedItem.Text + "' and empname like '" + txtEmpName.Text.Trim() + "%' order by empname");       
        repPB.DataSource = ds.Tables[0].DefaultView;
        repPB.DataBind();
        lblCountRrd.Text  = "共有 " + ds.Tables[0].Rows.Count + " 条已排班数据";
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        refreshData();
    }
    protected void btnNewPb_Click(object sender, EventArgs e)
    {
        Response.Write("<script>showsubpage('NewPaiban.aspx',1500,600)</script>");
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        divbg.Visible = true;
        divpop.Visible = true;
    }
    protected void repPB_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName.ToLower())
        {
            case "adjust":
                ((RadioButton)e.Item.FindControl("rbZaoban")).Visible = true;
                ((RadioButton)e.Item.FindControl("rbZhongban")).Visible = true;
                ((RadioButton)e.Item.FindControl("rbWanban")).Visible = true;
                ((TextBox)e.Item.FindControl("txtDT")).Visible = true;
                ((TextBox)e.Item.FindControl("txtDF")).Visible = true;
                ((Label)e.Item.FindControl("lblDT")).Visible = false;
                ((Label)e.Item.FindControl("lblDF")).Visible = false;
                ((Button)e.Item.FindControl("btnSave")).Visible = true;
                ((Button)e.Item.FindControl("btnCancel")).Visible = true;
                ((Button)e.Item.FindControl("btnAdj")).Visible = false ;
                //((Button)e.Item.FindControl("btnDel")).Visible = false;
                break;
            case "delete":
                
                //Response.Write("<script>confirm('真的要删除吗？');</script>");
                break;
            case "save":
                string sBan="";
                string sID = e.CommandArgument.ToString();
                string sDT = ((TextBox)e.Item.FindControl("txtDT")).Text;
                string sDF = ((TextBox)e.Item.FindControl("txtDF")).Text;
                ((Label)e.Item.FindControl("lblDT")).Text = sDT;
                ((Label)e.Item.FindControl("lblDF")).Text = sDF;
                if (((RadioButton)e.Item.FindControl("rbZaoban")).Checked)
                {
                    sBan = "早班";
                }
                else if (((RadioButton)e.Item.FindControl("rbZhongban")).Checked)
                {
                    sBan ="中班";
                }
                else if (((RadioButton)e.Item.FindControl("rbWanban")).Checked)
                {
                    sBan = "晚班";
                }
                if (sBan != "")
                {
                    ((Label)e.Item.FindControl("lblClass")).Text = sBan;
                }
                DBHelper.ExcSql("update EmployeeClass set datefrom='" + sDF + "',dateto='" + sDT + "',empclass='" + sBan + "' where id=" + sID);
                ((RadioButton)e.Item.FindControl("rbZaoban")).Visible = false;
                ((RadioButton)e.Item.FindControl("rbZhongban")).Visible = false;
                ((RadioButton)e.Item.FindControl("rbWanban")).Visible = false;
                ((TextBox)e.Item.FindControl("txtDT")).Visible = false;
                ((TextBox)e.Item.FindControl("txtDF")).Visible = false;
                ((Label)e.Item.FindControl("lblDT")).Visible = true ;
                ((Label)e.Item.FindControl("lblDF")).Visible = true;
                ((Button)e.Item.FindControl("btnSave")).Visible = false;
                ((Button)e.Item.FindControl("btnCancel")).Visible = false;
                ((Button)e.Item.FindControl("btnAdj")).Visible = true;
                //((Button)e.Item.FindControl("btnDel")).Visible = true;
                break;
            case "cancel":
                ((RadioButton)e.Item.FindControl("rbZaoban")).Visible = false;
                ((RadioButton)e.Item.FindControl("rbZhongban")).Visible = false;
                ((RadioButton)e.Item.FindControl("rbWanban")).Visible = false;
                ((TextBox)e.Item.FindControl("txtDT")).Visible = false;
                ((TextBox)e.Item.FindControl("txtDF")).Visible = false;
                ((Label)e.Item.FindControl("lblDT")).Visible = true ;
                ((Label)e.Item.FindControl("lblDF")).Visible = true;
                ((Button)e.Item.FindControl("btnSave")).Visible = false;
                ((Button)e.Item.FindControl("btnCancel")).Visible = false;
                ((Button)e.Item.FindControl("btnAdj")).Visible = true;
                //((LinkButton)e.Item.FindControl("btnDel")).Visible = true;
                break;
            default:
                break;
        }
    }

    
}