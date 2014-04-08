using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

//System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayofName
using System.Globalization;

public partial class Kaoqin_KQRrdUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpdateKQRrd_Click(object sender, EventArgs e)
    {
        
        if (txtDateF.Text.Trim().Equals("") || txtDateT.Text.Trim().Equals(""))
        {
            Response.Write("<script>alert('请输入日期');</script>");
            return;
        }
        ApplyEmp(int.Parse(Convert.ToDateTime(txtDateF.Text).Year.ToString()), int.Parse(Convert.ToDateTime(txtDateF.Text).Month.ToString()));
        ApplyClass(2013, 12);
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from kqorigindata where fdate>='" + txtDateF.Text + "' and fdate<='" + txtDateT.Text + "'");
            
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //打卡日期
            string carDate=ds.Tables[0].Rows[i]["fdate"].ToString();
            //员工编号
            string empNum = ds.Tables[0].Rows[i]["empNum"].ToString();
            //指纹号
            string fingerNum = ds.Tables[0].Rows[i]["fnum"].ToString();
            //打卡时间
            string carTime=ds.Tables[0].Rows[i]["ftime"].ToString();
            //班次
            string sClass=ds.Tables[0].Rows[i]["fclass"].ToString();
            //确定卡位
            string carPosition = CarPosition(carTime, sClass);
            if (carPosition == null)
            {
                return;
            }
            //分析跨天时间应该打在哪天
            carDate = ConfirmDate(sClass, carDate,carTime,carPosition);
            //写入
            DBHelper.ExcSql("update attendance set " + carPosition + "='" + carTime + "',fingerno=" + fingerNum + " where fingerdate='" + carDate + "' and emp_no=" + empNum);
        }
        Response.Write("<script>alert('考勤数据更新完成!');</script>");
    }
    /// <summary>
    /// 分析跨天时间应该打在哪天
    /// </summary>
    /// <param name="sClass"></param>
    /// <param name="sDate"></param>
    /// <param name="sTime"></param>
    /// <param name="carPos"></param>
    /// <returns></returns>
    string ConfirmDate(string sClass, string sDate, string sTime,string carPos)//返回日期字符串
    {
        string reDate = null;
        if (sClass == null || sClass.Trim() == "")//有分班
        {
            sClass = "unkown";
        }
        
        switch (sClass)
        {
            case "早班":
                if (carPos.ToLower() == "c6")
                {
                    if (Convert.ToDateTime(sTime) > Convert.ToDateTime("00:00:00"))
                    {
                        reDate= Convert.ToDateTime(sDate).AddDays(-1).ToShortDateString();
                    }
                }                
                break;
            case "中班":
                if (carPos.ToLower() == "c4")
                {
                    if (Convert.ToDateTime(sTime) > Convert.ToDateTime("00:00:00"))
                    {
                        reDate= Convert.ToDateTime(sDate).AddDays(-1).ToShortDateString();
                    }
                }
                else if (carPos.ToLower() == "c5" || carPos.ToLower() == "c6")
                {
                    reDate = Convert.ToDateTime(sDate).AddDays(-1).ToShortDateString();
                }
                break;
            case "晚班":
                if (carPos.ToLower() == "c1")
                {
                    if (Convert.ToDateTime(sTime) >= Convert.ToDateTime("00:00:00") && Convert.ToDateTime(sTime) <= Convert.ToDateTime("01:00:00"))
                    {
                        reDate = Convert.ToDateTime(sDate).AddDays(-1).ToShortDateString();
                    }
                }
                else
                {
                    reDate = Convert.ToDateTime(sDate).AddDays(-1).ToShortDateString();
                }
                break;
            case "unkown":
                break;
            case "长白班":
                break;
            case "长夜班":
                break;
            default:
                break;
        }
        if (reDate == null || reDate == "")
        {
            return sDate;
        }
        else
        {
            return reDate;
        }
    }
    /// <summary>
    /// 确定卡位
    /// </summary>
    /// <param name="sTime"></param>
    /// <param name="sClass"></param>
    /// <returns></returns>
    string CarPosition(string sTime,string sClass)
    {
        if (sClass == null||sClass.Trim()=="")//有分班
        { 
            sClass = "Unkown";
        }        
        string sql = "select * from carspec where classname='" + sClass + "' and timefrom<='" +
            sTime + ":00" + "'and timeto>='" + sTime + ":00" + "'";
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["fieldname"].ToString();
        }
        else//未设该时间段的打卡位置
        {
            Response.Write("<script>alert('未设置打卡段: 班次：" + sClass + ", 打卡时间:" + sTime + "');</script>");
            return null;            
        }
        
        
    }
    /// <summary>
    /// 写入员工到考勤表
    /// </summary>
    /// <param name="iYear"></param>
    /// <param name="iMonth"></param>
    void ApplyEmp(int iYear,int iMonth)
    {
        int iMax;
        DateTime dCurr;
        string dateF;string dateT;

        iMax = DateTime.DaysInMonth(iYear ,iMonth);
        dateF=iYear.ToString() + "-" + iMonth.ToString() + "-01";
        dateT=iYear.ToString() + "-" + iMonth.ToString() + "-" + iMax;
        

        //写入员工
        for (int i = 1; i <= iMax; i++)
        {
            dCurr =Convert.ToDateTime( iYear.ToString() + "-" + iMonth.ToString() + "-" + i);
            DBHelper.ExcSql("insert into attendance(department,emp_name,empposition,emp_no,fingerdate,wkday) select emp_depart,emp_name,emp_position,emp_no,'" +
                            dCurr + "','" + CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dCurr.DayOfWeek) + "' from employees where emp_state<>'已经离职'" +
                            " and emp_no not in(select emp_no from attendance where fingerdate='" + Convert.ToDateTime( iYear.ToString() + "-" + iMonth.ToString() + "-" + i) +
                            "')");         
        }
        //注明未入职
        DBHelper.ExcSql("update attendance set remark='未入职' from employees where fingerdate<employees.emp_intime  and attendance.emp_no=employees.emp_no " +
            "and attendance.fingerdate>='" + dateF + "' and attendance.fingerdate<='" + dateT + "'");

        //注明已离职
        DBHelper.ExcSql("update attendance set remark='已离职' from employees where fingerdate>employees.emp_leavedate and attendance.emp_no=employees.emp_no " +
            "and attendance.fingerdate>='" + dateF + "' and attendance.fingerdate<='" + dateT + "'");
    }
    /// <summary>
    /// 写入班次到考勤表
    /// </summary>
    /// <param name="iYear"></param>
    /// <param name="iMonth"></param>
    void ApplyClass(int iYear,int iMonth)
    {
        DateTime dF;
        DateTime dT;
        //写入班次
        dF=Convert.ToDateTime( iYear.ToString() + "-" + iMonth.ToString() + "-01");
        dT=Convert.ToDateTime( iYear.ToString() + "-" + iMonth.ToString() + "-" + DateTime.DaysInMonth(iYear,iMonth ));
        DBHelper.ExcSql("update attendance set empclass=employeeclass.empclass from employeeclass where attendance.emp_no=employeeclass.empNum " +
            "and attendance.fingerdate>=employeeclass.datefrom and attendance.fingerdate<=employeeclass.dateto and attendance.fingerdate>='" +
            dF + "' and attendance.fingerdate<='" + dT + "'");
    }

    
}