using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Kaoqin_KQUploadLocalTxt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fileName = Path.GetFileName(upload1.PostedFile.FileName);
        string filePath = Path.GetDirectoryName(upload1.PostedFile.FileName);
        string fullPath = Server.MapPath(".") + filePath + @"\" + fileName;
        Response.Write(HelperReadLocalTxt.ReadTxt(fullPath));
    }
}