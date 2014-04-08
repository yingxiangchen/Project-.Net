using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Windows;


/// <summary>
/// DataBind 的摘要说明
/// </summary>
public class DBDataBind
{
	public DBDataBind()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static  DataSet BindDepart()
    {
        
        DataSet ds = new DataSet();
        ds = DBHelper.SelectData("select * from department");
        return ds;

    }
}