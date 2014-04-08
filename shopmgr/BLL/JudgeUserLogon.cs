using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BLL
{
    /// <summary>
    /// 检测用户登录是否失效
    /// </summary>
    public  class JudgeUserLogon:System.Web.UI.Page
    {
        public JudgeUserLogon()
        {
            this.Load += new EventHandler(JudgeUserLogon_Load);
        }
        void JudgeUserLogon_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
            {
                Response.Redirect("~/userLogon.aspx");
            }
        }
    }
    
}
