using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Kaoqin_KQShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        ds=DBHelper.SelectData("select top 10 * from attendance order by id desc");
        rptEmp.DataSource = ds.Tables[0];
        rptEmp.DataBind();
        
    }
    protected void rptEmp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }
    DataSet GetEmpKQ(string empName,string Year="",string Month="")
    {
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select top 5 * from attendance where emp_name='" + empName + "'");
        return ds;
    }
    protected void rptEmp_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {        
        Repeater rpt = new Repeater();
        DataSet ds = new DataSet();
        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            rpt = (Repeater)e.Item.FindControl("rep");
            ds = GetEmpKQ("蔡春喜");
            rpt.DataSource = ds.Tables[0];
            rpt.DataBind();
        }
    }
}