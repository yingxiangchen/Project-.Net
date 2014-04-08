using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ManualFinger_ManualFingerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.lblTime.Text = DateTime.Now.ToString();
            LoadDepartList();
            initGrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData(lblDepart.Text, txtName.Text.Trim(), txtNum.Text.Trim());
        
    }
    void ClearField()
    {
        txtName.Text = "";
        txtNum.Text = "";
        lblDepart.Text = "";
        lblErrInfo.Text = "";
    }
    void SaveData(string empDepart, string empName, string empNum)
    {
        if (empDepart.Equals("") || empName.Equals("") || empNum.Equals(""))
        {
            lblErrInfo.Text = "数据不完整或有误，保存失败";
            return;
        }
        //检查是否已存在
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from manualfinger where mfnum=" + empNum);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblErrInfo.Text = "工号：" + empNum + " 已存在！请不要重复输入";
            return;
        }
        string userName="";
        if (!Session["userName"].Equals(null))
        {
            userName = Session["userName"].ToString();
        }
        DBHelper.ExcSql("insert into manualfinger(mfdate,mfdepart,mfname,mfNum,mfTime,updateby,updatetime) values('" + DateTime.Today.ToShortDateString() + 
            "','" + lblDepart.Text + "','" + txtName.Text.Trim() + "','" + txtNum.Text.Trim() + "','" + DateTime.Now.ToLongTimeString() + "','" + 
            userName + "','" + DateTime.Now.ToString() + "')");
        LoadMFList();
        ClearField();
        lblErrInfo.Text = "保存成功";
    }

    
    void LoadMFList()
    {
        DataSet ds = new DataSet();
        string sql;        
        sql = "select * from manualfinger";
       
        ds = DBHelper.SelectData(sql);
        rep.DataSource = ds.Tables[0];
        rep.DataBind();
        lblCount.Text = ds.Tables[0].Rows.Count.ToString();
    }
    void LoadDepartList()
    {
        //DataSet ds = new DataSet();
        //ds = DBHelper.SelectData("select * from department");
        //cboDepart.Items.Clear();
        //cboDepart.Items.Add("请选择");
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    if (ds.Tables[0].Rows[i]["Departname"].ToString().Trim() != "行政部" && ds.Tables[0].Rows[i]["Departname"].ToString().Trim() != "总经办")
        //    {
        //        cboDepart.Items.Add(ds.Tables[0].Rows[i]["Departname"].ToString());
        //    }

        //}
    }
    void initGrid()
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from Manualfinger");
        rep.DataSource = ds.Tables[0];
        rep.DataBind();
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        SearchEmpData(txtName.Text.Trim(), "");
    }
    void SearchEmpData(string empName,string empNum)
    {
        lblErrInfo.Text = "";
        if (empName.Trim().Equals("") && empNum.Trim().Equals(""))
        {
            lblErrInfo.Text = "员工姓名或工号两者必须输入其中一个";
            return;
        }
        DataSet ds = new DataSet();
        if (empNum.Trim() != "")//用员工工号查询员工数据
        {            
            ds = DBHelper.SelectData("select * from employees where emp_no=" + empNum);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.lblDepart.Text = ds.Tables[0].Rows[0]["emp_depart"].ToString();
                this.txtName.Text = ds.Tables[0].Rows[0]["emp_name"].ToString();
            }
        }
        if (!empName.Trim().Equals(""))//用姓名查询员工资料
        {
            ds = DBHelper.SelectData("select * from employees where emp_name='" + empName + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 1)//有同名员工
                {
                    lblErrInfo.Text = "存在两个或以上的同名员工：" + empName + "， 同名员工请查得工号，用工号输入。";
                    return;
                }
                this.lblDepart.Text = ds.Tables[0].Rows[0]["emp_depart"].ToString();
                this.txtNum.Text = ds.Tables[0].Rows[0]["emp_no"].ToString();
            }
        }
    }
    protected void txtNum_TextChanged(object sender, EventArgs e)
    {
        SearchEmpData("", txtNum.Text.Trim());
    }
    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        LoadMFList();
    }
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower().Equals("del"))
        {
            DBHelper.ExcSql("delete from manualfinger where id=" + e.CommandArgument.ToString());
            LoadMFList();
        }
    }
}