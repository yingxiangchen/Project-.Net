using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using myBLL;

public partial class Kaoqin_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["userName"] = "Administrator";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String savePath = Server.MapPath("~/kqrrd/"); // @"F:\111\";
        if (FileUpload1.HasFile)
        {
            String filename;
            
            filename = FileUpload1.FileName;            
            savePath += filename;
            FileUpload1.SaveAs(savePath);
            myBLL.FingerProcess.UploadTxtFingerList( HelperReadLocalTxt.ReadTxt (savePath),txtDateF.Text.Trim(),txtDateT.Text.Trim());
            myBLL.FingerProcess.BindOriginFingerToRepeater(Convert.ToDateTime(txtDateF.Text), Convert.ToDateTime(txtDateT.Text), rep);
        }
        else
        {
            Page.Response.Write("没有选择上传的文件");
        }
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        myDAL.DBHelper.ExcSql("delete from attendance where fingerdate>='2014-04-01'");
        myDAL.DBHelper.ExcSql("delete from attendance where fingerdate is null");
        Response.Write("ok");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string sql = "(select id,emp_no empnum,fingerno fnum,fingerdate fdate,c1,c2,c3,c4,c5,c6,c7,c8 from attendance where fingerdate>=@datefrom and fingerdate<=@dateto) " +
                "UNION(select id,empNum,fnum,fdate," +
                "(case when(ftime>'00:00' and ftime <='03:59') then ftime else null end)c1," +
                "(case when(ftime>'04:00' and ftime <='10:00') then ftime else null end)c2," +
                "(case when(ftime>'10:00' and ftime <='11:40') then ftime else null end)c3," +
                "(case when(ftime>'11:40' and ftime <='12:10') then ftime else null end)c4," +
                "(case when(ftime>'12:10' and ftime <='15:00') then ftime else null end)c5," +
                "(case when(ftime>'15:00' and ftime <='20:00') then ftime else null end)c6," +
                "(case when(ftime>'20:00' and ftime <='22:00') then ftime else null end)c7," +
                "(case when(ftime>'22:00' and ftime <='23:59') then ftime else null end)c8" +
                " from kqorigindata) ";
        SqlParameter[] sp = new SqlParameter[2];
        sp[0] = new SqlParameter("@datefrom", txtDateF.Text);
        sp[1] = new SqlParameter("@dateto", txtDateT.Text);
        ds=myDAL.DBHelper.SelectData(sql, sp);
        rpt.DataSource = ds.Tables[0];
        rpt.DataBind();
    }
}