using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BLL.Address.GetProvince(cboProvince);
            cboCity.Items.Insert(0, "请选择");
            cboDistrict.Items.Insert(0, "请选择");
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        
        lblInfo.Text= BLL.UserBll.AddUser(txtUserName.Text.Trim(), txtUserPwd.Text,txtUserPwdConfirm.Text );
    }

    protected void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        BLL.Address.GetCity(cboProvince.SelectedItem.Value, cboCity);
    }
    protected void cboCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        BLL.Address.GetDistrict(cboCity.SelectedItem.Value, cboDistrict);
    }
}