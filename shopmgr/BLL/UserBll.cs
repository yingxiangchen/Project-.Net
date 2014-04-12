using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;

namespace BLL
{
    public class UserBll
    {
        //注册新用户
        public static string AddUser(string userName, string userPwd, string confirmUserPwd, string userTel, string Province, string City, string District)
        {
            //CHECK DATA
            if (userName.Trim() == "") { return "用户名不能为空"; }
            if (userPwd.Trim() == "") { return "密码不能为空"; } 
            if (userPwd != confirmUserPwd) { return "两次输入的密码不相符"; }
            if (userTel.Trim() == null||userTel=="") { return "请输入手机号码"; }
            if (Province == "" || Province == "请选择"||Province==null) { return "请选择所在地省份"; }
            if (City == "" || City == "请选择"||City==null) { return "请选择所在地城市"; }
            if (District == "" || District == "请选择"||District==null) { return "请选择所在地区"; }
            if (CheckUserExists(userName)) { return "用户‘" + userName + "’已存在"; }
            //注册
            string sql = "insert into userlist(userName,userPwd,userTel,AddProvince,AddCity,AddDistrict) values(@username,@userpwd,@usertel,@province,@city,@district)";
            SqlParameter[] sp = new SqlParameter[6];
            sp[0] = new SqlParameter("@username", userName);
            sp[1] = new SqlParameter("@userpwd", MD5(userPwd));
            sp[2] = new SqlParameter("@userTel", userTel);
            sp[3] = new SqlParameter("@province", Province);
            sp[4] = new SqlParameter("@city", City);
            sp[5] = new SqlParameter("@district", District);
            if (DAL.DBReaderWriter.ExecuteSql(sql, sp)) { return "用户‘" + userName + "’注册成功"; }
            else { return "不可预知的错误，用户名：‘" + userName + "’注册不成功，请重试或联系统管理员"; }
        }
        //删除用户
        public static string DeleteUser(string userName)
        {
            if (!CheckUserExists(userName ))
            {
                return "用户：‘" + userName + "’不存在，删除失败";
            }
            string sql = "delete from userlist where username=@username";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@username", userName);
            if (DAL.DBReaderWriter.ExecuteSql(sql, sp))
            {
                return "删除成功";
            }
            else
            {
                return "未知错误，删除失败，请重试或联系系统管理员";
            }
        }
        //更改用户密码
        public static string ChangeUserPwd(string userName, string userPwd, string newUserPwd, string confirmUserPwd)
        {
            if (userName.Trim() == "")
            {
                return "请输入正确的用户名";
            }
            if (!CheckUserExists(userName))
            {
                return "用户名：‘" + userName + "’不存在";
            }
            if (CheckPwd(userName, userPwd) == "密码错误")
            {
                return "原密码错误";
            }
            if (newUserPwd.Trim() == "")
            {
                return "新密码不能为空";
            }
            if (newUserPwd != confirmUserPwd)
            {
                return "两次新密码不相符";
            }
            string sql = "update userlist set userpwd=@newpwd where username=@username";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@newpwd", MD5(newUserPwd));
            sp[1] = new SqlParameter("@username", userName);
            bool x = DAL.DBReaderWriter.ExecuteSql(sql, sp);
            if (x)
            {
                return "密码修改成功，请记住新密码";
            }
            else
            {
                return "未知错误，密码修改失败，请重试或联系系统管理员";
            }
        }
        //检查用户是否存在
        static bool CheckUserExists(string userName)
        {
            DataSet ds = new DataSet();
            string sql = "select * from userlist where username=@username";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@username", userName);
            ds = DAL.DBReaderWriter.SelectData(sql, sp);
            return ds.Tables[0].Rows.Count > 0;
        }
        //用户登录
        public static string UserLogon(string userName, string userPwd, string RedirectURL=null)
        {
            if (userName.Trim() == "")
            {
                return "请输入用户名";
            }
            string s = CheckPwd(userName, userPwd);
            if (s != "密码正确")
            {
                return s;
            }
            else
            {
                if (RedirectURL != null) { HttpContext.Current.Response.Redirect(RedirectURL);}
                HttpContext.Current.Session["userName"] = userName;
                return "已登录";
            }
        }
        //检查用户密码
        public  static string  CheckPwd(string userName, string userPwd)
        {
            if (!CheckUserExists(userName))
            {
                return "用户名不存在";
            }
            DataSet ds = new DataSet();
            string sql = "select * from userlist where username=@username";
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@username", userName);
            ds = DAL.DBReaderWriter.SelectData(sql, sp);
            bool x= ds.Tables[0].Rows[0]["userpwd"].ToString() == MD5(userPwd);
            if (!x)
            {
                return "密码错误";
            }
            return "密码正确";
        }
        //Encipher
        public static string MD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString().ToUpper();
        }

        //检查用户是否有效.
        public static bool CheckUserLogoned()
        {
            if (HttpContext.Current.Session["username"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
