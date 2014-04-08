using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public class Address
    {
        //省
        public static DataSet GetProvince(DropDownList DropDownlist=null)
        {
            DataSet ds = new DataSet();
            string sql="select * from addprovince";            
            ds = DAL.DBReaderWriter.SelectData(sql);
            if (DropDownlist != null)
            {
                DropDownlist.DataSource = ds.Tables[0];
                DropDownlist.DataTextField = "pName";
                DropDownlist.DataValueField = "id";
                DropDownlist.DataBind();
                DropDownlist.Items.Insert(0, "请选择");
                DropDownlist.SelectedIndex = 0;
            }
            return ds;
        }
        //市
        public static DataSet GetCity(string ProvinceId, DropDownList cbo = null)
        {
            DataSet ds = new DataSet();
            string sql = "select * from addcity where pid=@pid";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@pid", ProvinceId);
            ds = DAL.DBReaderWriter.SelectData(sql, sp);
            if (cbo != null)
            {
                cbo.DataSource = ds.Tables[0];
                cbo.DataTextField = "cName";
                cbo.DataValueField = "id";
                cbo.DataBind();
                cbo.Items.Insert(0, "请选择");
                cbo.SelectedIndex = 0;
            }
            return ds;
        }
        //区
        public static DataSet GetDistrict(string CityId, DropDownList cbo = null)
        {
            DataSet ds = new DataSet();
            string sql = "select * from adddistrict where cid=@cid";
            SqlParameter[] sp=new SqlParameter[1];
            sp[0] = new SqlParameter("@cid", CityId);
            ds = DAL.DBReaderWriter.SelectData(sql, sp);
            if (cbo != null)
            {
                cbo.DataSource = ds.Tables[0];
                cbo.DataTextField = "dName";
                cbo.DataValueField = "id";
                cbo.DataBind();
                cbo.Items.Insert(0, "请选择");
                cbo.SelectedIndex = 0;
            }
            return ds;
        }
    }
}
