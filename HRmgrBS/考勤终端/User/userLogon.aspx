<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userLogon.aspx.cs" Inherits="User_userLogon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
    <link href="../MyCss/myCss.css" rel="stylesheet" />
    <script type="text/javascript" >
        function closeWin() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divUserLogon">
        <asp:Label ID="l" Width="150px" runat="server" Text="用户名：" CssClass="lbl"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="txt"></asp:TextBox><br />
        <asp:Label ID="Label2" Width="150px" runat="server" Text="登录密码：" CssClass="lbl"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="txt"></asp:TextBox><br /><br /><br />
        <asp:Button ID="btnLogon" Width="100px" runat="server" Text="登录" />
        <asp:Button ID="btnClose" Width="100px" runat="server" Text="关闭" OnClientClick="closeWin()" />
    </div>
    </form>
</body>
</html>
