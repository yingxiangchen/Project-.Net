<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KQUploadLocalTxt.aspx.cs" Inherits="Kaoqin_KQUploadLocalTxt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>读取本地文本考勤记录</title>
    <link href="../MyCss/myCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divUser">
            <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="btnLogon" runat="server" CssClass="Linkbtn">登录</asp:LinkButton>
            <asp:LinkButton ID="btnLogonOut" runat="server" CssClass="Linkbtn">退出</asp:LinkButton>
        </div>
        <div>
            <br />
            <asp:FileUpload runat="server" ID="upload1" Width="500px" />
            <asp:Button ID="btnUpload" runat="server" Text="开始上传" OnClick="btnUpload_Click" />
        </div>
    </form>
</body>
</html>
