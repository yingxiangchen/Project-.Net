using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Kaoqin_UbnormalKQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = this.Title + " - [" + Request.QueryString["empName"] + "]";
        if (!IsPostBack)
        {
            string empNum = Request.QueryString["empNum"];
            empName.Text = Request.QueryString["empName"];
            empDepart.Text = Request.QueryString["empDepart"];
            empPosition.Text = Request.QueryString["empPosition"];
            empAttn.Text = Request.QueryString["attn"];
            BindKQbyName();
            
        }
    }
    protected void rep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label l = new Label();
            l = (Label)e.Item.FindControl("lblAbr");

            if (l.Text == "")
            {
                RadioButton r = new RadioButton();
                r = (RadioButton)e.Item.FindControl("optQJ");
                r.Visible = false;
                r = (RadioButton)e.Item.FindControl("optMDK");
                r.Visible = false;
                r = (RadioButton)e.Item.FindControl("optKG");
                r.Visible = false;
                r = (RadioButton)e.Item.FindControl("optOther");
                r.Visible = false;
                TextBox t = new TextBox();
                t = (TextBox)e.Item.FindControl("txtExplain");
                t.Visible = false;
                ((Label)e.Item.FindControl("lblExplain")).Visible = true;
                ((TextBox)e.Item.FindControl("txtExplain")).Visible = false;
            }
            else
            {
                ((Label)e.Item.FindControl("lblExplain")).Visible = false;
                ((TextBox)e.Item.FindControl("txtExplain")).Visible = true;
            }
        }
    }
    void BindKQbyName()
    {

        string dateF;
        string dateT;
        
        string empNum = Request.QueryString["empNum"];
        string syear = Request.QueryString["year"]; //cboYear.SelectedItem.Text; //Request.QueryString["year"];
        string smonth = Request.QueryString["month"]; //cboMonth.SelectedItem.Text; //Request.QueryString["month"];
        string sql;
       
        dateF = syear + "/" + smonth + "/1";
        dateT = syear + "/" + smonth + "/" + DateTime.DaysInMonth(Convert.ToInt32(syear), Convert.ToInt32(smonth));

        sql = "Select * from attendance where  fingerdate>='" + dateF + "' and fingerdate<='" + dateT +
              "' and emp_no = '" + empNum  + "' order by emp_no, fingerdate";


        DataSet ds = new DataSet();
        ds = DBHelper.SelectData(sql);

        rep.DataSource = ds.Tables[0].DefaultView;
        rep.DataBind();
        

    }
    void SaveAbr()
    {
        btnSave.Enabled = false;
        for (int i = 0; i < rep.Items.Count; i++)
        {

            //string sAbrReason;
            bool blQJ = false;
            bool blMDK = false;
            bool blKG = false;
            bool blOther = false;
            CheckBox cb = new CheckBox();

            cb = (CheckBox)rep.Items[i].FindControl("optQJ");
            blQJ = cb.Checked;
            cb = (CheckBox)rep.Items[i].FindControl("optMDK");
            blMDK = cb.Checked;
            cb = (CheckBox)rep.Items[i].FindControl("optKG");
            blKG = cb.Checked;
            cb = (CheckBox)rep.Items[i].FindControl("optOther");
            blOther = cb.Checked;
            TextBox t = new TextBox();
            t = (TextBox)rep.Items[i].FindControl("txtExplain");
            if (blOther == true)
            {
                if (t.Text.Trim() == "")
                {
                    t.BackColor = Color.Red;
                    ClientScript.RegisterStartupScript(GetType(), "w", "<script>promptandforward('保存失败！如选择其它类型，必须输入异常原因。')</script>");
                    lblInfo.Text = "保存失败！如选择其它类型，必须输入异常原因";
                    btnSave.Enabled = true;
                    return;
                }
                else
                {
                    t.BorderColor = Color.White;
                }
            }

            //保存
            Label l = new Label();
            l = (Label)rep.Items[i].FindControl("lblId");
            bool blnResult = DBHelper.ExcSql("update attendance set AbnormalExplain='" + t.Text.Trim() + "', abqj='" +
                blQJ + "',abmdk='" + blMDK + "',abkg='" + blKG + "',abother='" + blOther +
                "' where id=" + l.Text);
            if (blnResult == true)
            {
                ClientScript.RegisterStartupScript(GetType(), "a", "<script>promptandforward('保存成功！')</script>");
                lblInfo.Text = "保存成功";
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "x", "<script>promptandforward('保存失败！请检查原因。')</script>");
                lblInfo.Text = "保存失败！请检查原因";
            }
        }
        
        btnSave.Enabled = true;
        //if (rep.Items.Count > 0)
        //{
        //    lblRrd.Text = "";
        //}
        //else
        //{
        //    lblRrd.Text = "没有数据";
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveAbr();
    }
}