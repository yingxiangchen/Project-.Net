using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Kaoqin_KQSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDepartList();
            BindGrid(cboDepart.SelectedItem.Text,txtName.Text.Trim());
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindGrid(cboDepart.SelectedItem.Text, txtName.Text.Trim());
    }
    void BindGrid(string department,string empName)
    {
        if (department.Equals("请选择"))
        {
            department = "";
        }
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select dayoffdays,gongxiudays,kuanggongdays,department as depart,emp_name as empname,emp_no as empNum,empPosition, sum(attn) as empsysattn,atualattn from attendance where " +
            "department like '" + department + "%' and emp_name like '" + empName + "%' and fingerdate>='" + txtDF.Text + "' and fingerdate<='" + txtDT.Text +
            "' group by department,emp_Name,emp_No,atualattn,dayoffdays,gongxiudays,kuanggongdays,empPosition");
        rep.DataSource = ds.Tables[0].DefaultView;
        rep.DataBind();        
        lblCount.Text = "共 " + ds.Tables[0].Rows.Count.ToString() + " 名员工";
        
    }
    void LoadDepartList()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from department");
        cboDepart.Items.Clear();
        cboDepart.Items.Add("请选择");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //if (ds.Tables[0].Rows[i]["Departname"].ToString().Trim() != "行政部" && ds.Tables[0].Rows[i]["Departname"].ToString().Trim() != "总经办")
            //{
                cboDepart.Items.Add(ds.Tables[0].Rows[i]["Departname"].ToString());
            //}

        }
    }
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName.ToLower())
        {
            case "saveall":
                SaveAll();
                break;
            case "save":
                string at=((TextBox) e.Item.FindControl("txtEmpAtualAttn")).Text;
                SaveData(at, e.CommandArgument.ToString());
                break;
            case "edit":
                foreach (RepeaterItem ri in rep.Items)
                {
                    ri.FindControl("txtEmpAtualAttn").Visible = true;
                    ri.FindControl("lblEmpAtualAttn").Visible = false;
                    ri.FindControl("btnSave").Visible = true;
                }
                break;
            case "cancel":
                foreach (RepeaterItem ri in rep.Items)
                {
                    ri.FindControl("txtEmpAtualAttn").Visible = false;
                    ri.FindControl("lblEmpAtualAttn").Visible = true;
                    ri.FindControl("btnSave").Visible = false;
                }
                break;
            default:
                break;
        }
        
    }
    protected void btnSaveAll_Click(object sender, EventArgs e)
    {

        SaveAll();
    }
    void SaveAll()
    {
        foreach (RepeaterItem ri in rep.Items)
        {
            if (ri.FindControl("txtEmpAtualAttn").Visible == true)
            {
                SaveData(((TextBox)ri.FindControl("txtEmpAtualAttn")).Text, ((Label)ri.FindControl("lblempNum")).Text);
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "fdk", "<script>alert('保存成功!');</script>");
    }
    void SaveData(string AtualAttnDays,string empNum)
    {
        if (AtualAttnDays.Trim().Equals(""))
        {
            return;
        }
        DBHelper.ExcSql("update attendance set atualattn=" + AtualAttnDays + " where emp_no=" + empNum +
                " and fingerdate>='" + txtDF.Text.Trim() + "' and fingerdate<='" + txtDT.Text.Trim() + "'");        
    }
    protected void btnRefreshDayoff_Click(object sender, EventArgs e)
    {
        DBHelper.ExcSql("update attendance set attendance.dayoffdays=b.dayoffdays from (select empno,sum(dayoffdays) as dayoffdays from dayoff group by empno) b " +
            txtDF.Text + "' and attendance.fingerdate<='" + txtDT.Text +
            "' and attendance.emp_no=dayoff.empno and attendance.fingerdate>=dayoff.dayoffFrom and attendance.fingerdate<=dayoff.dayoffTo");
    }
}